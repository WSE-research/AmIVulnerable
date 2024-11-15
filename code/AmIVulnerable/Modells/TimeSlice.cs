﻿using MP = Modells.Project;
using System.Text.Json.Serialization;
namespace Modells {
    public class TimeSlice {
        public string TagName { get; set; } = "No tag or latest!";
        public DateTime Timestamp { get; set; }
        public int CountDirectDependencies { get; set; }
        public int CountTransitiveDependencies { get; set; }
        public int CountUniqueTransitiveDependencies { get; set; }
        public int CountKnownDirectVulnerableDependencies { get; set; }
        public int CountKnownTransitiveVulnerableDependencies { get; set; }
        public int CountKnownUniqueTransitiveVulnerableDependencies { get; set; }
        public int CountToDateDirectVulnerableDependencies { get; set; }
        public int CountToDateTransitiveVulnerableDependencies { get; set; }
        public int CountToDateUniqueTransitiveVulnerableDependencies { get; set; }
        public int CountTotalFoundVulnerabilities { get; set; }
        [JsonIgnore]
        public MP.ProjectTypeEnum ProjectEcosystem { get; set; }
    }
}
