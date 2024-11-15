﻿//using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis;
//using Modells;
//using MySql.Data.MySqlClient;
//using Newtonsoft.Json;
//using SerilogTimings;
//using System.Data;
//using System.Diagnostics;
//using System.Text.RegularExpressions;
//using CM = System.Configuration.ConfigurationManager;

//namespace AmIVulnerable.Controllers {

//    /// <summary>Interact direct with the database, like create the cve-table or request packages.</summary>
//    //[Route("api/[controller]")]
//    //[ApiController]
//    public class DbController : ControllerBase {

//        #region Config
//        private readonly IConfiguration Configuration;

//        public DbController(IConfiguration configuration) {
//            Configuration = configuration;
//        }
//        #endregion

//        #region Controller

//        /// <summary>Update the Database, if it exists already.</summary>
//        /// <returns></returns>
//        //[HttpPost]
//        //[Route("update")]
//        public IActionResult UpdateCveDatabase() {
//            using (Operation.Time("UpdateCveDatabase")) {
//                try {
//                    // MySql Connection
//                    MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:cvedb"]);

//                    MySqlCommand cmdTestIfTableExist = new MySqlCommand($"" +
//                        $"SELECT COUNT(*) " +
//                        $"FROM information_schema.TABLES " +
//                        $"WHERE (TABLE_SCHEMA = 'cve') AND (TABLE_NAME = 'cve');", connection);
                    
//                    connection.Open();
//                    int count = cmdTestIfTableExist.ExecuteNonQuery();
//                    connection.Close();

//                    if (count == 0) {
//                        return BadRequest("Table does not exist!\nPlease download cve data and create the database before trying to update it using the update route!");
//                    }

//                    //start update process
//                    try {
//                        ProcessStartInfo process = new ProcessStartInfo {
//                            FileName = "bash",
//                            RedirectStandardInput = true,
//                            WorkingDirectory = $"",
//                        };

//                        Process runProcess = Process.Start(process)!;
//                        runProcess.StandardInput.WriteLine($"git " +
//                            $"clone {CM.AppSettings["StandardCveUrlPlusTag"]!} " +  // git url
//                            $"raw");                                                // target dir
//                        runProcess.StandardInput.WriteLine($"exit");
//                        runProcess.WaitForExit();
//                    }
//                    catch (Exception ex) {
//                        return BadRequest(ex.StackTrace);
//                    }

//                    //read the file List
//                    List<string> fileList = new List<string>();
//                    List<int> indexToDelete = new List<int>();
//                    string path = "raw";
//                    ExploreFolder(path, fileList);

//                    //filter for json files
//                    foreach (int i in Enumerable.Range(0, fileList.Count)) {
//                        if (!Regex.IsMatch(fileList[i], @"CVE-[-\S]+.json")) {
//                            indexToDelete.Add(i);
//                        }
//                    }
//                    foreach (int i in Enumerable.Range(0, indexToDelete.Count)) {
//                        fileList.RemoveAt(indexToDelete[i] - i);
//                    }

//                    // Drop Index for faster insert
//                    MySqlCommand cmdIndexDrop = new MySqlCommand("CALL drop_index_on_designation_if_exists();", connection);
                    
//                    connection.Open();
//                    cmdIndexDrop.ExecuteNonQuery();
//                    connection.Close();

//                    //start insert/update in MySQL
//                    int insertAndUpdateIndex = 0;
//                    foreach (string x in fileList) {
//                        string insertIntoString = "INSERT INTO cve(cve_number, designation, version_affected, full_text) " +
//                            "VALUES(@cve, @des, @ver, @ful) " +
//                            "ON DUPLICATE KEY UPDATE " +
//                            "version_affected = @ver, " +
//                            "full_text = @ful;" ;
//                        MySqlCommand cmdInsert = new MySqlCommand(insertIntoString, connection);

//                        string json = System.IO.File.ReadAllText(x);
//                        CVEcomp cve = JsonConvert.DeserializeObject<CVEcomp>(json)!;

//                        string affected = "";
//                        foreach (Affected y in cve.containers.cna.affected) {
//                            foreach (Modells.Version z in y.versions) {
//                                affected += z.version + $"({z.status}) |";
//                            }
//                        }
//                        if (affected.Length > 25_000) {
//                            affected = "to long -> view full_text";
//                        }
//                        string product = "| ";
//                        try {
//                            foreach (Affected singleProduct in cve.containers.cna.affected) {
//                                product += singleProduct.product + " | ";
//                            }
//                            if (product.Length > 1000) {
//                                product = product[0..1000];
//                            }
//                            if (product.Equals("| ")) {
//                                product = "n/a";
//                            }
//                        }
//                        catch {
//                            product = "n/a";
//                        }
//                        cmdInsert.Parameters.AddWithValue("@cve", cve.cveMetadata.cveId);
//                        cmdInsert.Parameters.AddWithValue("@des", product);
//                        cmdInsert.Parameters.AddWithValue("@ver", affected);
//                        cmdInsert.Parameters.AddWithValue("@ful", JsonConvert.SerializeObject(cve, Formatting.None));

//                        connection.Open();
//                        insertAndUpdateIndex += cmdInsert.ExecuteNonQuery();
//                        connection.Close();
//                    }

//                    //connection.Open();
//                    //MySqlCommand cmdIndexCreated = new MySqlCommand("CREATE INDEX idx_designation ON cve (designation);", connection);
//                    //cmdIndexCreated.ExecuteNonQuery();
//                    //connection.Close();

//                    return Ok(insertAndUpdateIndex);
//                }
//                catch (Exception ex) {
//                    return BadRequest(ex.StackTrace + "\n\n" + ex.Message);
//                }
//            }
//        }

//        /// <summary>Return the full text of a cve, when it is requested.</summary>
//        /// <param name="cve_number"></param>
//        /// <returns></returns>
//        //[HttpGet]
//        //[Route("getFullTextFromCveNumber")]
//        public IActionResult GetFullTextCve([FromQuery] string? cve_number) {
//            if (!(this.Request.Headers.Accept.Equals("application/json") || this.Request.Headers.Accept.Equals("*/*"))) {
//                return StatusCode(406);
//            }
//            using (Operation.Time("GetFullTextCve")) {
//                if (cve_number is null) {
//                    return BadRequest("Empty cve_number");
//                }
//                try {
//                    // MySql Connection
//                    MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:cvedb"]);

//                    connection.Open();
//                    MySqlCommand cmdIndexCreated = new MySqlCommand($"" +
//                        $"SELECT full_text " +
//                        $"FROM cve.cve " +
//                        $"WHERE cve_number = '{cve_number}';", connection);
//                    MySqlDataReader reader = cmdIndexCreated.ExecuteReader();
//                    DataTable resDataTable = new DataTable();
//                    resDataTable.Load(reader);
//                    connection.Close();

//                    if (resDataTable.Rows.Count == 0) {
//                        return NoContent();
//                    }

//                    CVEcomp? cVEcomp = JsonConvert.DeserializeObject<CVEcomp>(resDataTable.Rows[0]["full_text"].ToString()!);

//                    return Ok(cVEcomp);
//                }
//                catch (Exception ex) {
//                    return BadRequest(ex.StackTrace + "\n\n" + ex.Message);

//                }
//            }
//        }

//        /// <summary>Check for an cve entry of a package with all its versions</summary>
//        /// <param name="packageName">Name of package to search</param>
//        /// <param name="isDbSearch">true: search db, false: search raw-json</param>
//        /// <param name="packageVersion">Version of package to search</param>
//        /// <returns>Ok with result. NoContent if empty.</returns>
//        //[HttpGet]
//        //[Route("checkSinglePackage")]
//        public IActionResult CheckSinglePackage([FromQuery] string PackageName,
//                                                    [FromQuery] string? PackageVersion) {
//            if (!(this.Request.Headers.Accept.Equals("application/json") || this.Request.Headers.Accept.Equals("*/*"))) {
//                return StatusCode(406);
//            }
//            using (Operation.Time($"Complete Time for Query-SingleSearch after Package \"{PackageName}\"")) {
//                List<CveResult> results = [];
//                DataTable dtResult = SearchInMySql(PackageName);
//                // convert the result
//                foreach (DataRow x in dtResult.Rows) {
//                    CveResult y = new CveResult() {
//                        CveNumber = x["cve_number"].ToString() ?? "",
//                        Designation = x["designation"].ToString() ?? "",
//                        Version = x["version_affected"].ToString() ?? ""
//                    };
//                    CVEcomp temp = JsonConvert.DeserializeObject<CVEcomp>(x["full_text"].ToString() ?? string.Empty) ?? new CVEcomp();
//                    try {
//                        if (temp.containers.cna.metrics.Count != 0) {
//                            y.CvssV31 = temp.containers.cna.metrics[0].cvssV3_1;
//                        }
//                        if (temp.containers.cna.descriptions.Count != 0) {
//                            y.Description = temp.containers.cna.descriptions[0];
//                        }
//                    }
//                    finally {
//                        results.Add(y);
//                    }
//                }
//                // return's
//                if (results.Count > 0) {
//                    JsonLdObject resultAsJsonLd = new JsonLdObject() {
//                        Context = "https://localhost:7203/views/cveResult",
//                        Data = results
//                    };
//                    return Ok(resultAsJsonLd);
//                }
//                else {
//                    return NoContent();
//                }
//            }
//        }

//        /// <summary>
//        /// Search for a list of packages.
//        /// Not useable in swagger because of body - but curl works fine.
//        /// </summary>
//        /// <param name="packages">List of tuple: package, version</param>
//        /// <returns>OK, if exists. OK, if no package list searched. NoContent if not found.</returns>
//        //[HttpGet]
//        //[Route("checkPackageList")]
//        public async Task<IActionResult> CheckPackageListAsync([FromBody] List<PackageForApi> packages) {
//            if (!(this.Request.Headers.Accept.Equals("application/json") || this.Request.Headers.Accept.Equals("*/*"))) {
//                return StatusCode(406);
//            }
//            List<CveResult> results = [];
//            using (Operation.Time($"Complete Time for Query-Search after List of Packages")) {
//                foreach (PackageForApi x in packages) {
//                    DataTable dtResult = SearchInMySql(x.PackageName);
//                    // convert the result
//                    foreach (DataRow y in dtResult.Rows) {
//                        CveResult z = new CveResult() {
//                            CveNumber = y["cve_number"].ToString() ?? "",
//                            Designation = y["designation"].ToString() ?? "",
//                            Version = y["version_affected"].ToString() ?? ""
//                        };
//                        CVEcomp temp = JsonConvert.DeserializeObject<CVEcomp>(y["full_text"].ToString() ?? string.Empty) ?? new CVEcomp();
//                        try {
//                            if (temp.containers.cna.metrics.Count != 0) {
//                                z.CvssV31 = temp.containers.cna.metrics[0].cvssV3_1;
//                            }
//                            if (temp.containers.cna.descriptions.Count != 0) {
//                                z.Description = temp.containers.cna.descriptions[0];
//                            }
//                        }
//                        finally {
//                            results.Add(z);
//                        }
//                    }
//                }
//            }

//            JsonLdObject resultAsJsonLd = new JsonLdObject() {
//                Context = "https://localhost:7203/views/cveResult",
//                Data = results
//            };
//            return Ok(results.Count == 0 ? "No result" : resultAsJsonLd);
//        }

//        //[HttpGet]
//        //[Route("checkGuid")]
//        public IActionResult CheckDownloadedProjectWithGuid([FromQuery] Guid projectGuid) {
//            // MySql Connection
//            MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:cvedb"]);

//            MySqlCommand cmd = new MySqlCommand($"" +
//                $"SELECT * " +
//                $"FROM repositories " +
//                $"WHERE guid='{projectGuid}';", connection);

//            DataTable dataTable = new DataTable();
//            connection.Open();
//            MySqlDataReader reader = cmd.ExecuteReader();
//            dataTable.Load(reader);
//            connection.Close();

//            if (dataTable.Rows.Count == 1) {
//                object res = new {
//                    guid = dataTable.Rows[0]["guid"].ToString(),
//                    repoUrl = dataTable.Rows[0]["repoUrl"].ToString(),
//                    repoOwner = dataTable.Rows[0]["repoOwner"].ToString(),
//                    repoDesignation = dataTable.Rows[0]["repoDesignation"].ToString(),
//                    tag = dataTable.Rows[0]["tag"].ToString()
//                };
//                return Ok(res);
//            }
//            else {
//                return NotFound("Not found");
//            }
//        }
//        #endregion

//        #region Internal function(s)
//        /// <summary>
//        /// Adds file names of all files of a folder and its subfolders to a list
//        /// </summary>
//        /// <param name="folderPath">path to target folder</param>
//        /// <param name="fileList">list of files</param>
//        private static void ExploreFolder(string folderPath, List<string> fileList) {
//            try {
//                fileList.AddRange(Directory.GetFiles(folderPath));

//                foreach (string subfolder in Directory.GetDirectories(folderPath)) {
//                    ExploreFolder(subfolder, fileList);
//                }
//            }
//            catch (Exception ex) {
//                Console.WriteLine($"{ex.Message}");
//            }
//        }

//        /// <summary>Search package in raw-json data</summary>
//        /// <param name="packageName">Name of package to search</param>
//        /// <returns>List of CveResults</returns>
//        private List<CveResult> SearchInJson(string packageName) {
//            List<string> fileList = new List<string>();
//            List<int> indexToDelete = new List<int>();
//            string path = $"{AppDomain.CurrentDomain.BaseDirectory}raw";
//            ExploreFolder(path, fileList);

//            foreach (int i in Enumerable.Range(0, fileList.Count)) {
//                if (!Regex.IsMatch(fileList[i], @"CVE-[-\S]+.json")) {
//                    indexToDelete.Add(i);
//                }
//            }
//            foreach (int i in Enumerable.Range(0, indexToDelete.Count)) {
//                fileList.RemoveAt(indexToDelete[i] - i);
//            }
//            // search in the files
//            List<CveResult> results = [];
//            using (Operation.Time($"Package \"{packageName}\"")) {
//                int start = 0;
//                foreach (int i in Enumerable.Range(start, fileList.Count - start)) {
//                    CVEcomp item = JsonConvert.DeserializeObject<CVEcomp>(System.IO.File.ReadAllText(fileList[i]))!;
//                    if (i % 100 == 0) {
//                        Console.WriteLine(fileList[i] + " - " + i);
//                    }
//                    if (item.containers.cna.affected is null || item.containers.cna.affected.Any(x => x.product is null)) {
//                        continue;
//                    }
//                    if (item.containers.cna.affected.Any(y => y.product.Equals(packageName))) {
//                        foreach (int j in Enumerable.Range(0, item.containers.cna.affected.Count)) {
//                            foreach (Modells.Version version in item.containers.cna.affected[j].versions) {
//                                results.Add(new CveResult() {
//                                    CveNumber = item.cveMetadata.cveId,
//                                    Version = version.version,
//                                });
//                            }
//                        }
//                    }
//                }
//            }
//            return results;
//        }

//        private DataTable SearchInMySql(string packageName) {
//            // MySql Connection
//            MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:cvedb"]);

//            MySqlCommand cmd = new MySqlCommand($"" +
//                $"SELECT cve_number, designation, version_affected, full_text " +
//                $"FROM cve.cve " +
//                $"WHERE designation='{packageName}';", connection);

//            DataTable dataTable = new DataTable();
//            using (Operation.Time($"Query-Time for Package \"{packageName}\"")) {
//                // read the result
//                connection.Open();
//                MySqlDataReader reader = cmd.ExecuteReader();
//                dataTable.Load(reader);
//                connection.Close();
//            }
//            return dataTable;
//        }
//        #endregion
//    }
//}
