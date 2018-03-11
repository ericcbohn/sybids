using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
// using Newtonsoft.Json.Converters;

namespace sybids.Models {
    public class LineModel {
        //[JsonProperty("_id", Required = Required.AllowNull), BsonId]
        // [JsonIgnore, BsonId]
        // public ObjectId _id { get; set; }

        [JsonProperty("lineid"), BsonElement("lineid")]
        public string LineId { get; set; }

        [JsonProperty("base"), BsonElement("base")]
        public string Base { get; set; }

        [JsonProperty("equipment"), BsonElement("equipment")]
        public string Equipment { get; set; }

        [JsonProperty("position"), BsonElement("position")]
        public string Position { get; set; }

        [JsonProperty("blockminutes"), BsonElement("blockminutes")]//, JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan BlockMinutes { get; set; }

        [JsonProperty("creditminutes"), BsonElement("creditminutes")]//, JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan CreditMinutes { get; set; }

        [JsonProperty("days"), BsonElement("days")]
        public List<DayModel> Days { get; set; }
    }

    public class DayModel {
        [JsonProperty("month"), BsonElement("month")]
        public string Month { get; set; }

        [JsonProperty("day"), BsonElement("day")]
        public int Day { get; set; }

        [JsonProperty("pairingid"), BsonElement("pairingid")]
        public List<string> PairingId { get; set; }
    }

    public class PairingModel {
        // TODO: _id mongo object id

        [JsonProperty("pairingid"), BsonElement("pairingid")]
        public string PairingId { get; set; }

        [JsonProperty("base"), BsonElement("base")]
        public string Base { get; set; }

        [JsonProperty("numdays"), BsonElement("numdays")]
        public int NumDays { get; set; }

        [JsonProperty("block"), BsonElement("block"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan Block { get; set; }

        [JsonProperty("credit"), BsonElement("credit"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan Credit { get; set; }

        [JsonProperty("landings"), BsonElement("landings")]
        public int Landings { get; set; }

        [JsonProperty("deadheads"), BsonElement("deadheads")]
        public int Deadheads { get; set; }

        [JsonProperty("tafb"), BsonElement("tafb"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan TAFB { get; set; }

        [JsonProperty("duty"), BsonElement("duty")]
        public List<DutyModel> Duty { get; set; }
    }

    public class DutyModel {
        [JsonProperty("dutyday"), BsonElement("dutyday")]
        public string DutyDay { get; set; }

        [JsonProperty("legs"), BsonElement("legs")]
        public int Legs { get; set; }

        [JsonProperty("brief"), BsonElement("brief"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan Brief { get; set; }

        [JsonProperty("debrief"), BsonElement("debrief"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan Debrief { get; set; }

        [JsonProperty("dutytime"), BsonElement("dutytime"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan DutyTime { get; set; }

        [JsonProperty("block"), BsonElement("block"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan Block { get; set; }

        [JsonProperty("credit"), BsonElement("credit"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan Credit { get; set; }

        [JsonProperty("rest"), BsonElement("rest"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan Rest { get; set; }

        [JsonProperty("resttype"), BsonElement("resttype")]
        public int RestType { get; set; }

        [JsonProperty("leg"), BsonElement("leg")]
        public List<LegModel> Leg { get; set; }
    }

    public class LegModel {
        [JsonProperty("legnum"), BsonElement("legnum")]
        public int LegNum { get; set; }

        [JsonProperty("equipment"), BsonElement("equipment")]
        public string Equipment { get; set; }

        [JsonProperty("fleetcode"), BsonElement("fleetcode")]
        public string FleetCode { get; set; }

        [JsonProperty("flight"), BsonElement("flight")]
        public int Flight { get; set; }

        [JsonProperty("departure"), BsonElement("departure")]
        public string Departure { get; set; }

        [JsonProperty("arrival"), BsonElement("arrival")]
        public string Arrival { get; set; }

        [JsonProperty("departuretime"), BsonElement("departuretime"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan DepartureTime { get; set; }

        [JsonProperty("arrivaltime"), BsonElement("arrivaltime"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan ArrivalTime { get; set; }

        [JsonProperty("block"), BsonElement("block"), JsonConverter(typeof(JsonTimeSpanConverter))]
        public BidTimeSpan Block { get; set; }

        [JsonProperty("carrier"), BsonElement("carrier")]
        public string Carrier { get; set; }
    }

    public struct BidTimeSpan : IComparable, IComparable<BidTimeSpan>, IEquatable<BidTimeSpan>, IFormattable
    {
        public int Hours { get; set;  }
        public int Minutes { get; set; }

        public BidTimeSpan(int hours, int minutes) {
            Hours = hours;
            Minutes = minutes;
        }

        public static BidTimeSpan Parse(string time) {
            if (!Regex.IsMatch(time, @"^\d{1,2}:\d{2}$")) throw new ArgumentException("invalid time format");
            var hours = Convert.ToInt16(string.Format("{0}{1}", time[0], time[1]));
            var minutes = Convert.ToInt16(string.Format("{0}{1}", time[3], time[4]));
            return new BidTimeSpan(hours, minutes);
        }

        public int CompareTo(object obj)
        {
            if(obj is BidTimeSpan) {
                return CompareTo((BidTimeSpan)obj);
            }
            return 0;
        }

        public int CompareTo(BidTimeSpan other)
        {
            if (Hours > other.Hours) return 1;
            if(Hours == other.Hours) {
                if (Minutes > other.Minutes) return 1;
            }
            return 0;
        }

        public bool Equals(BidTimeSpan other)
        {
            if (Hours == other.Hours && Minutes == other.Minutes) return true;
            return false;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{0}:{1}", Hours, Minutes);
        }
    }
}

// export interface MongoObjId {
//     timestamp: string;
//     machine: string;
//     pid: string;
//     increment: string;
//     creationTime: string;
// }