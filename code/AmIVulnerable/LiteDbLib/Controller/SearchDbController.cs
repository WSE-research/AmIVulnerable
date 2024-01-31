﻿using LiteDB;
using Modells;
using System.Text.RegularExpressions;
using CM = System.Configuration.ConfigurationManager;

namespace LiteDbLib.Controller {

    public class SearchDbController {

        #region Config
        /// <summary>Return the location, where the database is located.</summary>
        private static string SaveDir {
            get {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data")) {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Data");
                }
                return (AppDomain.CurrentDomain.BaseDirectory + "Data");
            }
        }

        private List<string> dbFiles = new List<string>();

        /// <summary>Define the name of the table.</summary>
        private readonly string tableName = "cve";
        #endregion


        /// <summary></summary>
        /// <returns></returns>
        public SearchDbController() {
            Regex yearDb = new Regex(@"(\d{4}).litedb");
            DirectoryInfo currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory
                                                               + CM.AppSettings["PathToDbs"]);
            FileInfo[] files = currentDirectory.GetFiles();

            foreach (FileInfo file in files) {
                dbFiles.Add(file.Name);
            }
        }

        /// <summary></summary>
        /// <returns></returns>
        public List<CveResult> SearchSinglePackage(string designation) {
            List<CveResult> results = [];
            foreach (string dbFile in dbFiles) {
                Console.WriteLine($"Akutell - {dbFile}");
                using (LiteDatabase db = new LiteDatabase($"{SaveDir}\\{dbFile}")) {
                    ILiteCollection<CVEcomp> col = db.GetCollection<CVEcomp>(tableName);

                    IEnumerator<CVEcomp> pointer = col.Query().ToEnumerable().GetEnumerator();

                    while (pointer.MoveNext()) {
                        CVEcomp item = pointer.Current;
                        if (item.containers.cna.affected is null || item.containers.cna.affected.Any(x => x.product is null)) {
                            continue;
                        }
                        if (item.containers.cna.affected.Any(y => y.product.Equals(designation))) {
                            foreach (int i in Enumerable.Range(0, item.containers.cna.affected.Count)) {
                                foreach (Modells.Version version in item.containers.cna.affected[i].versions) {
                                    results.Add(new CveResult() {
                                        CveNumber = item.cveMetadata.cveId,
                                        Version = version.version,
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return results;
        }

        public async Task<List<CveResult>> SearchPackagesAsList(List<string> designations) {
            List<CveResult> results = [];
            int pipeCount = 0;
            int s = Enumerable.Range(1, designations.Count).Sum();
            for (int i = 0; i < designations.Count; i += 1) {
                if (pipeCount < s) { // fill pipe
                    int j = i;
                    int k = dbFiles.Count - 1;
                    while (j >= 0 && k >= 0) {
                        Task<List<CveResult>>[] tasks = new Task<List<CveResult>>[j + 1];
                        foreach (int k2 in Enumerable.Range(0, dbFiles.Count - 1)) {
                            string db = dbFiles[k];
                            string des = designations[j];
                            tasks[k2] = Task.Run(() => SearchInDb(db, des));
                            pipeCount += 1;
                            k -= 1; j -= 1;
                            if (j < 0) {
                                break;
                            }
                        }
                        List<CveResult>[] res = await Task.WhenAll(tasks);
                        await Console.Out.WriteLineAsync(); // only for debug check
                        foreach (List<CveResult> x in res) {
                            results.AddRange(x);
                        }
                    }
                    if (i == (designations.Count - 1)) {
                        i -= 1; // if pipe filled let check the pipeCount again and reset so the highest element
                    }
                }
                else if (
                            (
                                (designations.Count > dbFiles.Count) && ((pipeCount - dbFiles.Count) < s)
                            ) // more designations, so check the dbCounter
                            ||
                            (
                                (designations.Count < dbFiles.Count) && (pipeCount - designations.Count) < s)
                            ) // more dbFiles, so check the designationCounter
                        { // fill the pipe with new items and remove old
                    int j = i;
                    int k = dbFiles.Count - 2;
                    while (j >= 0 && k >= 0) {
                        Task<List<CveResult>>[] tasks = new Task<List<CveResult>>[j + 1];
                        foreach (int k2 in Enumerable.Range(0, dbFiles.Count - 1)) {
                            string db = dbFiles[k];
                            string des = designations[j];
                            tasks[k2] = Task.Run(() => SearchInDb(db, des));
                            pipeCount += 1;
                            k -= 1; j -= 1;
                            if (j < 0) {
                                break;
                            }
                        }
                        List<CveResult>[] res = await Task.WhenAll(tasks);
                        await Console.Out.WriteLineAsync(); // only for debug check
                        foreach (List<CveResult> x in res) {
                            results.AddRange(x);
                        }
                        if (k >= 0) {
                            j = i;
                            k += (designations.Count - 1);
                        }
                    }
                }
                else { // drain the pipe
                    pipeCount += 1;
                }
                await Console.Out.WriteLineAsync(i.ToString());
            }
            return results;
        }

        private async Task<List<CveResult>> SearchInDb(string dbFile, string designation) {
            await Console.Out.WriteLineAsync($"{dbFile} search for {designation}"); // only for debug check
            List<CveResult> results = [];
            using (LiteDatabase db = new LiteDatabase($"{SaveDir}\\{dbFile}")) {
                ILiteCollection<CVEcomp> col = db.GetCollection<CVEcomp>(tableName);

                IEnumerator<CVEcomp> pointer = col.Query().ToEnumerable().GetEnumerator();

                while (pointer.MoveNext()) {
                    CVEcomp item = pointer.Current;
                    if (item.containers.cna.affected is null || item.containers.cna.affected.Any(x => x.product is null)) {
                        continue;
                    }
                    if (item.containers.cna.affected.Any(y => y.product.Equals(designation))) {
                        foreach (int i in Enumerable.Range(0, item.containers.cna.affected.Count)) {
                            foreach (Modells.Version version in item.containers.cna.affected[i].versions) {
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
    }
}
