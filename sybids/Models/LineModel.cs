using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace sybids.Models {
    public class LineModel {
        //[JsonProperty("_id", Required = Required.AllowNull), BsonId]
        [JsonIgnore, BsonId]
        public ObjectId _id { get; set; }
        [JsonProperty("datecreatedutc"), BsonElement("datecreatedutc")]
        public DateTime DateCreatedUtc { get; set; }
        [JsonProperty("lineid"), BsonElement("lineid")]
        public int LineId { get; set; }
        [JsonProperty("base"), BsonElement("base"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Base { get; set; }
        [JsonProperty("position"), BsonElement("position"), JsonConverter(typeof(StringEnumConverter))]
        public Position Position { get; set; }
        [JsonProperty("blockminutes"), BsonElement("blockminutes")]
        public int BlockMinutes { get; set; }
        [JsonProperty("creditminutes"), BsonElement("creditminutes")]
        public int CreditMinutes { get; set; }
        [JsonProperty("days"), BsonElement("days")]
        public List<DayModel> Days { get; set; }
    }

    public class DayModel {
        public DateTime ReportTimeUtc { get; set; }
        public DateTime ReleaseTimeUtc { get; set; }
        public List<PairingModel> Pairings { get; set; }
    }

    public class PairingModel {
        public int Flight { get; set; }
        [JsonProperty("departure"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Departure { get; set; }
        [JsonProperty("destination"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Destination { get; set; }
        public bool IsDeadhead { get; set; }
    }
}