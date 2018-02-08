using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace sybids.Models {
    public class LineModel {
        public ObjectId MongoID { get; set; }
        public int LineID { get; set; }
        [JsonProperty("Base"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Base { get; set; }
        [JsonProperty("Position"), JsonConverter(typeof(StringEnumConverter))]
        public Position Position { get; set; }
        public int BlockMinutes { get; set; }
        public int CreditMinutes { get; set; }
        public List<DayModel> Days { get; set; }
    }

    public class DayModel {
        public DateTime ReportTimeUtc { get; set; }
        public DateTime ReleaseTimeUtc { get; set; }
        public List<PairingModel> Pairings { get; set; }
    }

    public class PairingModel {
        public int Flight { get; set; }
        [JsonProperty("Departure"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Departure { get; set; }
        [JsonProperty("Destination"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Destination { get; set; }
        public bool IsDeadhead { get; set; }
    }
}