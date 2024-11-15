﻿using Modells.DTO;
using Modells.Packages;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using F = System.IO.File;
using MPP = Modells.Packages.Package;

namespace Modells.OsvResult {
    public class OsvResult {
        [JsonProperty("results")]
        [JsonPropertyName("results")]
        public List<Result> results { get; set; } = [];

        [JsonProperty("experimental_config")]
        [JsonPropertyName("experimental_config")]
        public ExperimentalConfig experimental_config { get; set; }

        private readonly static string CLI = "cmd";

        public OsvResult OsvExtractVulnerabilities(Project project) {
            if(project.ProjectType == Project.ProjectTypeEnum.npm) {
                ExecuteCommand("osv-scanner", " --no-ignore --format json . > osv.json", project.DirGuid);
            }
            else {
                if(!MakeCustomOsvLock(project)) {
                    return new OsvResult();
                }
            }
            return JsonConvert.DeserializeObject<OsvResult>(F.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + project.DirGuid + "/osv.json")) ?? new OsvResult();
        }
        private bool MakeCustomOsvLock(Project project) {
            List<MPP> packages = GetAllPackages(project.Packages);
            List<CustomPackage> customPackages = new List<CustomPackage>();
            if(packages.Count() == 0) {
                return false;
            }
            foreach (MPP package in packages) {
                //Maven is sadly hardcoded rn
                customPackages.Add(new CustomPackage(package.Name, package.Version, "Maven"));
            }
            CustomOsvLock customOsvLock = new CustomOsvLock();
            customOsvLock.results.Add(new CustomResult(customPackages));
            F.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + project.DirGuid + "/custom-osv-scanner.json", JsonConvert.SerializeObject(customOsvLock));
            Console.WriteLine("Made custom lockfile");
            ExecuteCommand("osv-scanner", " --no-ignore --format json --lockfile osv-scanner:custom-osv-scanner.json > osv.json", project.DirGuid);
            return true;
        }
        private List<MPP> GetAllPackages(List<MPP> packages) {
            List<MPP> packagesResult = new List<MPP>();
            foreach (MPP package in packages) {
                packagesResult.Add(package);
                if (package.Dependencies != null) {
                    packagesResult.AddRange(GetAllPackages(package.Dependencies));
                }
            }
            return packagesResult;
        }
        private void ExecuteCommand(string prog, string command, string dir) {
            ProcessStartInfo process = new ProcessStartInfo {
                FileName = CLI,
                RedirectStandardInput = true,
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + dir,
            };
            Process runProcess = Process.Start(process)!;
            runProcess.StandardInput.WriteLine($"{prog} {command}");
            runProcess.StandardInput.WriteLine($"exit");
            runProcess.WaitForExit();
        }
    }
    public class Affected {
        [JsonProperty("package")]
        [JsonPropertyName("package")]
        public AffectedPackage affectedPackage { get; set; }

        [JsonProperty("ranges")]
        [JsonPropertyName("ranges")]
        public List<Range> ranges { get; set; }

        [JsonProperty("database_specific")]
        [JsonPropertyName("database_specific")]
        public DatabaseSpecific database_specific { get; set; }
    }

    public class DatabaseSpecific {
        [JsonProperty("source")]
        [JsonPropertyName("source")]
        public string source { get; set; }

        [JsonProperty("cwe_ids")]
        [JsonPropertyName("cwe_ids")]
        public List<string> cwe_ids { get; set; }

        [JsonProperty("github_reviewed")]
        [JsonPropertyName("github_reviewed")]
        public bool github_reviewed { get; set; }

        [JsonProperty("github_reviewed_at")]
        [JsonPropertyName("github_reviewed_at")]
        public DateTime? github_reviewed_at { get; set; } = new DateTime();

        [JsonProperty("nvd_published_at")]
        [JsonPropertyName("nvd_published_at")]
        public DateTime? nvd_published_at { get; set; } = new DateTime();

        [JsonProperty("severity")]
        [JsonPropertyName("severity")]
        public string severity { get; set; }
    }

    public class Event {
        [JsonProperty("introduced")]
        [JsonPropertyName("introduced")]
        public string introduced { get; set; }

        [JsonProperty("fixed")]
        [JsonPropertyName("fixed")]
        public string @fixed { get; set; }
    }

    public class ExperimentalConfig {
        [JsonProperty("licenses")]
        [JsonPropertyName("licenses")]
        public Licenses licenses { get; set; }
    }

    public class Group {
        [JsonProperty("ids")]
        [JsonPropertyName("ids")]
        public List<string> ids { get; set; }

        [JsonProperty("aliases")]
        [JsonPropertyName("aliases")]
        public List<string> aliases { get; set; }
    }

    public class Licenses {
        [JsonProperty("summary")]
        [JsonPropertyName("summary")]
        public bool summary { get; set; }

        [JsonProperty("allowlist")]
        [JsonPropertyName("allowlist")]
        public object allowlist { get; set; }
    }

    public class Packages {
        [JsonProperty("package")]
        [JsonPropertyName("package")]
        public Package package { get; set; }

        [JsonProperty("vulnerabilities")]
        [JsonPropertyName("vulnerabilities")]
        public List<Vulnerability> vulnerabilities { get; set; }

        [JsonProperty("groups")]
        [JsonPropertyName("groups")]
        public List<Group> groups { get; set; }
    }

    public class AffectedPackage {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonProperty("ecosystem")]
        [JsonPropertyName("ecosystem")]
        public string ecosystem { get; set; }

        [JsonProperty("purl")]
        [JsonPropertyName("purl")]
        public string purl { get; set; }
    }

    public class Package {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonProperty("version")]
        [JsonPropertyName("version")]
        public string version { get; set; }

        [JsonProperty("ecosystem")]
        [JsonPropertyName("ecosystem")]
        public string ecosystem { get; set; }
    }

    public class Range {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("events")]
        [JsonPropertyName("events")]
        public List<Event> events { get; set; }
    }

    public class Reference {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("url")]
        [JsonPropertyName("url")]
        public string url { get; set; }
    }

    public class Result {
        [JsonProperty("source")]
        [JsonPropertyName("source")]
        public Source source { get; set; }

        [JsonProperty("packages")]
        [JsonPropertyName("packages")]
        public List<Packages> packages { get; set; }
    }

    public class Severity {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("score")]
        [JsonPropertyName("score")]
        public string score { get; set; }
    }

    public class Source {
        [JsonProperty("path")]
        [JsonPropertyName("path")]
        public string path { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }
    }

    public class Vulnerability {
        [JsonProperty("modified")]
        [JsonPropertyName("modified")]
        public DateTime modified { get; set; } = new DateTime();

        [JsonProperty("published")]
        [JsonPropertyName("published")]
        public DateTime published { get; set; } = new DateTime();

        [JsonProperty("schema_version")]
        [JsonPropertyName("schema_version")]
        public string schema_version { get; set; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonProperty("aliases")]
        [JsonPropertyName("aliases")]
        public List<string> aliases { get; set; } = [];

        [JsonProperty("summary")]
        [JsonPropertyName("summary")]
        public string summary { get; set; }

        [JsonProperty("details")]
        [JsonPropertyName("details")]
        public string details { get; set; }

        [JsonProperty("affected")]
        [JsonPropertyName("affected")]
        public List<Affected> affected { get; set; } = [];

        [JsonProperty("severity")]
        [JsonPropertyName("severity")]
        public List<Severity> severity { get; set; } = [];

        [JsonProperty("references")]
        [JsonPropertyName("references")]
        public List<Reference> references { get; set; } = [];

        [JsonProperty("database_specific")]
        [JsonPropertyName("database_specific")]
        public DatabaseSpecific database_specific { get; set; }
    }
}
