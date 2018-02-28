// using System;
// using System.Collections.Generic;
// using MongoDB.Bson;
// using MongoDB.Bson.Serialization.Attributes;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Converters;

// namespace sybids.Models {
//     public class LineModel {
//         //[JsonProperty("_id", Required = Required.AllowNull), BsonId]
//         [JsonIgnore, BsonId]
//         public ObjectId _id { get; set; }
//         [JsonProperty("lineid"), BsonElement("lineid")]
//         public int LineId { get; set; }
//         [JsonProperty("base"), BsonElement("base"), JsonConverter(typeof(StringEnumConverter))]
//         public Airport Base { get; set; }
//         [JsonProperty("numdaysoff"), BsonElement("numdaysoff")]
//         public int NumDaysOff { get; set; }
//         [JsonProperty("tafb"), BsonElement("tafb")]
//         public int TAFB { get; set; }
//         [JsonProperty("position"), BsonElement("position"), JsonConverter(typeof(StringEnumConverter))]
//         public Position Position { get; set; }
//         [JsonProperty("blockminutes"), BsonElement("blockminutes")]
//         public int BlockMinutes { get; set; }
//         [JsonProperty("creditminutes"), BsonElement("creditminutes")]
//         public int CreditMinutes { get; set; }
//         [JsonProperty("days"), BsonElement("days")]
//         public List<DayModel> Days { get; set; }
//     }

//     public class DayModel {
//         [JsonProperty("day"), BsonElement("day")]
//         public int Day { get; set; }
//         [JsonProperty("isoff"), BsonElement("isoff")]
//         public bool IsOff { get; set; }
//         [JsonProperty("reporttimeutc"), BsonElement("reporttimeutc")]
//         public DateTime ReportTimeUtc { get; set; }
//         [JsonProperty("releasetimeutc"), BsonElement("releasetimeutc")]
//         public DateTime ReleaseTimeUtc { get; set; }
//         [JsonProperty("pairings"), BsonElement("pairings")]
//         public List<PairingModel> Pairings { get; set; }
//     }

//     public class PairingModel {
//         [JsonProperty("flight"), BsonElement("flight")]
//         public int Flight { get; set; }
//         [JsonProperty("departure"), JsonConverter(typeof(StringEnumConverter))]
//         public Airport Departure { get; set; }
//         [JsonProperty("destination"), JsonConverter(typeof(StringEnumConverter))]
//         public Airport Destination { get; set; }
//         [JsonProperty("isdeadhead"), BsonElement("isdeadhead")]
//         public bool IsDeadhead { get; set; }
//     }
// }