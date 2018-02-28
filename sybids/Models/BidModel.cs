using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace sybids.Models {
    public class BidModel {
        [JsonIgnore, BsonId]
        public ObjectId _id { get; set; }

        [JsonProperty("bidId"), BsonElement("bidId")]
        public int BidId { get; set; }

        [JsonProperty("bidDate"), BsonElement("bidDate")]
        public DateTime BidDate { get; set; }

        [JsonProperty("position"), BsonElement("position"), JsonConverter(typeof(StringEnumConverter))]
        public Position Position { get; set; }

        [JsonProperty("pairing"), BsonElement("pairing")]
        public List<PairingModel> Pairing { get; set; }
    }

    public class PairingModel { 
        [JsonIgnore, BsonId]
        public ObjectId _id { get; set; }

        [JsonProperty("pairingid"), BsonElement("pairingid")]
        public string PairingId { get; set; }

        [JsonProperty("base"), BsonElement("base"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Base { get; set; }

        [JsonProperty("numdays"), BsonElement("numdays")]
        public int NumDays { get; set; }

        [JsonProperty("block"), BsonElement("block")]
        public TimeSpan Block { get; set; }

        [JsonProperty("credit"), BsonElement("credit")]
        public TimeSpan Credit { get; set; }

        [JsonProperty("landings"), BsonElement("landings")]
        public int Landings { get; set; }

        [JsonProperty("deadheads"), BsonElement("deadheads")]
        public int Deadheads { get; set; }

        [JsonProperty("tafb"), BsonElement("tafb")]
        public TimeSpan TAFB { get; set; }
        
        [JsonProperty("duty"), BsonElement("duty")]
        public List<DutyModel> Duty { get; set; }
    }

    public class DutyModel { 
        [JsonProperty("dutyDay"), BsonElement("dutyDay")]
        public int DutyDay { get; set; }

        [JsonProperty("legs"), BsonElement("legs")]
        public int Legs { get; set; }

        [JsonProperty("dutyTime"), BsonElement("dutyTime")]
        public TimeSpan DutyTime { get; set; }

        [JsonProperty("block"), BsonElement("block")]
        public TimeSpan Block { get; set; }

        [JsonProperty("credit"), BsonElement("credit")]
        public TimeSpan Credit { get; set; }

        [JsonProperty("rest"), BsonElement("rest")]
        public TimeSpan Rest { get; set; }

        [JsonProperty("restType"), BsonElement("restType")]
        public int RestType { get; set; }

        [JsonProperty("brief"), BsonElement("brief")]
        public TimeSpan Brief { get; set; }

        [JsonProperty("debrief"), BsonElement("debrief")]
        public TimeSpan Debrief { get; set; }

        [JsonProperty("leg"), BsonElement("leg")]
        public List<LegModel> Leg { get; set; }
    }

    public class LegModel { 
        [JsonProperty("legNum"), BsonElement("legNum")]
        public int LegNum { get; set; }

        // 73G, ERJ, 738, CR9, etc.
        [JsonProperty("equipment"), BsonElement("equipment")]
        public string Equipment { get; set; }

        // 738, 73G, DHD
        [JsonProperty("fleetCode"), BsonElement("fleetCode")]
        public string FleetCode { get; set; }

        [JsonProperty("flight"), BsonElement("flight")]
        public int Flight { get; set; }

        [JsonProperty("departure"), BsonElement("departure"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Departure { get; set; }

        [JsonProperty("arrival"), BsonElement("arrival"), JsonConverter(typeof(StringEnumConverter))]
        public Airport Arrival { get; set; }

        [JsonProperty("departureTime"), BsonElement("departureTime")]
        public TimeSpan DepartureTime { get; set; }

        [JsonProperty("arrivalTime"), BsonElement("arrivalTime")]
        public TimeSpan ArrivalTime { get; set; }

        [JsonProperty("block"), BsonElement("block")]
        public TimeSpan Block { get; set; }

        [JsonProperty("carrier"), BsonElement("carrier")]
        public string Carrier { get; set; }
    }
}