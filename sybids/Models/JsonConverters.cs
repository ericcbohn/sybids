using System;
using Newtonsoft.Json;
using sybids.Models;

namespace sybids.Models
{
    public class JsonTimeSpanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BidTimeSpan);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var rawVal = reader.Value as string; // time format from csv does not include ':' (i.e. 800 for 8:00am)
            var len = rawVal.Length;
            var min = string.Empty;
            var hr = string.Empty;
            if(len == 1) {
                min = string.Format("{0}{1}", "0", rawVal[0]);
                hr = "00";
            }
            else if(len == 2) {
                min = string.Format("{0}{1}", rawVal[0], rawVal[1]);
                hr = "00";
            }
            else if(len == 3) {
                min = string.Format("{0}{1}", rawVal[1], rawVal[2]);
                hr = string.Format("{0}{1}", "0", rawVal[0]);
            }
            else {
                min = string.Format("{0}{1}", rawVal[2], rawVal[3]);
                hr = string.Format("{0}{1}", rawVal[0], rawVal[1]);
            }
            var time = BidTimeSpan.Parse(string.Format("{0}:{1}", hr, min));

            return time;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var time = (BidTimeSpan)value;
            serializer.Serialize(writer, time.ToString());
            //throw new NotImplementedException();
        }
    }
}
