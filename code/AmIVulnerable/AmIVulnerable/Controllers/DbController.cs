﻿using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Modells;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using SerilogTimings;
using System.Data;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace AmIVulnerable.Controllers {

    /// <summary>Interact direct with the database, like create the cve-table or request packages.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase {

        #region Config
        private readonly IConfiguration Configuration;

        public DbController(IConfiguration configuration) {
            Configuration = configuration;
        }
        #endregion

        #region Controller
        /// <summary>Check for an cve entry of a package with all its versions</summary>
        /// <param name="packageName">Name of package to search</param>
        /// <param name="isDbSearch">true: search db, false: search raw-json</param>
        /// <param name="packageVersion">Version of package to search</param>
        /// <returns>Ok with result. NoContent if empty.</returns>
        [HttpPost]
        [Route("checkSinglePackage")]
        public IActionResult CheckSinglePackage([FromBody] PackageForApi packageName) {
            using (Operation.Time($"Complete Time for Query-SingleSearch after Package \"{packageName}\"")) {
                List<CveResult> results = [];
                DataTable dtResult = SearchInMySql(packageName.PackageName);
                // convert the result
                foreach (DataRow x in dtResult.Rows) {
                    CveResult y = new CveResult() {
                        CveNumber = x["cve_number"].ToString() ?? "",
                        Designation = x["designation"].ToString() ?? "",
                        Version = x["version_affected"].ToString() ?? ""
                    };
                    CVEcomp temp = JsonConvert.DeserializeObject<CVEcomp>(x["full_text"].ToString() ?? string.Empty) ?? new CVEcomp();
                    try {
                        if (temp.containers.cna.metrics.Count != 0) {
                            y.CvssV31 = temp.containers.cna.metrics[0].cvssV3_1;
                        }
                        if (temp.containers.cna.descriptions.Count != 0) {
                            y.Description = temp.containers.cna.descriptions[0];
                        }
                    }
                    finally {
                        results.Add(y);
                    }
                }
                // return's
                if (results.Count > 0) {
                    JsonLdObject resultAsJsonLd = new JsonLdObject() {
                        Context = "https://localhost:7203/views/cveResult",
                        Data = results
                    };
                    return Ok(resultAsJsonLd);
                }
                else {
                    return NoContent();
                }
            }
        }

        /// <summary>
        /// Search for a list of packages
        /// </summary>
        /// <param name="packages">List of tuple: package, version</param>
        /// <returns>OK, if exists. OK, if no package list searched. NoContent if not found.</returns>
        [HttpPost]
        [Route("checkPackageList")]
        public async Task<IActionResult> CheckPackageListAsync([FromBody] List<PackageForApi> packages) {
            List<CveResult> results = [];
            using (Operation.Time($"Complete Time for Query-Search after List of Packages")) {
                foreach (PackageForApi x in packages) {
                    DataTable dtResult = SearchInMySql(x.PackageName);
                    // convert the result
                    foreach (DataRow y in dtResult.Rows) {
                        CveResult z = new CveResult() {
                            CveNumber = y["cve_number"].ToString() ?? "",
                            Designation = y["designation"].ToString() ?? "",
                            Version = y["version_affected"].ToString() ?? ""
                        };
                        CVEcomp temp = JsonConvert.DeserializeObject<CVEcomp>(y["full_text"].ToString() ?? string.Empty) ?? new CVEcomp();
                        try {
                            if (temp.containers.cna.metrics.Count != 0) {
                                z.CvssV31 = temp.containers.cna.metrics[0].cvssV3_1;
                            }
                            if (temp.containers.cna.descriptions.Count != 0) {
                                z.Description = temp.containers.cna.descriptions[0];
                            }
                        }
                        finally {
                            results.Add(z);
                        }
                    }
                }
            }

            JsonLdObject resultAsJsonLd = new JsonLdObject() {
                Context = "https://localhost:7203/views/cveResult",
                Data = results
            };
            return Ok(results.Count == 0 ? "No result" : resultAsJsonLd);
        }

        [HttpGet]
        [Route("CheckGuid")]
        public IActionResult CheckDownloadedProjectWithGuid([FromHeader] Guid projectGuid) {
            // MySql Connection
            MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:cvedb"]);

            MySqlCommand cmd = new MySqlCommand($"" +
                $"SELECT * " +
                $"FROM repositories " +
                $"WHERE guid='{projectGuid}';", connection);

            DataTable dataTable = new DataTable();
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            connection.Close();

            if (dataTable.Rows.Count == 1) {
                object res = new {
                    guid = dataTable.Rows[0]["guid"].ToString(),
                    repoUrl = dataTable.Rows[0]["repoUrl"].ToString(),
                    repoOwner = dataTable.Rows[0]["repoOwner"].ToString(),
                    repoDesignation = dataTable.Rows[0]["repoDesignation"].ToString(),
                    tag = dataTable.Rows[0]["tag"].ToString()
                };
                return Ok(res);
            }
            else {
                return NotFound("Not found");
            }
        }
        #endregion

        #region Internal function(s)
        /// <summary>
        /// Adds file names of all files of a folder and its subfolders to a list
        /// </summary>
        /// <param name="folderPath">path to target folder</param>
        /// <param name="fileList">list of files</param>
        private static void ExploreFolder(string folderPath, List<string> fileList) {
            try {
                fileList.AddRange(Directory.GetFiles(folderPath));

                foreach (string subfolder in Directory.GetDirectories(folderPath)) {
                    ExploreFolder(subfolder, fileList);
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"{ex.Message}");
            }
        }

        /// <summary>Search package in raw-json data</summary>
        /// <param name="packageName">Name of package to search</param>
        /// <returns>List of CveResults</returns>
        private List<CveResult> SearchInJson(string packageName) {
            List<string> fileList = new List<string>();
            List<int> indexToDelete = new List<int>();
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}raw";
            ExploreFolder(path, fileList);

            foreach (int i in Enumerable.Range(0, fileList.Count)) {
                if (!Regex.IsMatch(fileList[i], @"CVE-[-\S]+.json")) {
                    indexToDelete.Add(i);
                }
            }
            foreach (int i in Enumerable.Range(0, indexToDelete.Count)) {
                fileList.RemoveAt(indexToDelete[i] - i);
            }
            // search in the files
            List<CveResult> results = [];
            using (Operation.Time($"Package \"{packageName}\"")) {
                int start = 0;
                foreach (int i in Enumerable.Range(start, fileList.Count - start)) {
                    CVEcomp item = JsonConvert.DeserializeObject<CVEcomp>(System.IO.File.ReadAllText(fileList[i]))!;
                    if (i % 100 == 0) {
                        Console.WriteLine(fileList[i] + " - " + i);
                    }
                    if (item.containers.cna.affected is null || item.containers.cna.affected.Any(x => x.product is null)) {
                        continue;
                    }
                    if (item.containers.cna.affected.Any(y => y.product.Equals(packageName))) {
                        foreach (int j in Enumerable.Range(0, item.containers.cna.affected.Count)) {
                            foreach (Modells.Version version in item.containers.cna.affected[j].versions) {
                                results.Add(new CveResult() {
                                    CveNumber = item.cveMetadata.cveId,
                                    Version = version.version,
                                });
                            }
                        }
                    }
                }
            }
            return results;
        }

        private DataTable SearchInMySql(string packageName) {
            // MySql Connection
            MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:cvedb"]);

            MySqlCommand cmd = new MySqlCommand($"" +
                $"SELECT cve_number, designation, version_affected, full_text " +
                $"FROM cve.cve " +
                $"WHERE designation='{packageName}';", connection);

            DataTable dataTable = new DataTable();
            using (Operation.Time($"Query-Time for Package \"{packageName}\"")) {
                // read the result
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dataTable.Load(reader);
                connection.Close();
            }
            return dataTable;
        }
        #endregion
    }
}
