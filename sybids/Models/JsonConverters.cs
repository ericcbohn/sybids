using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

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
            if(len == 5) {
                var digit = "0";
                if (rawVal[0] != ' ') digit = string.Format("{0}", rawVal[0]);
                hr = string.Format("{0}{1}", digit, rawVal[1]);
                min = string.Format("{0}{1}", rawVal[3], rawVal[4]);
            }
            else if (len == 4) {
                hr = string.Format("{0}{1}", rawVal[0], rawVal[1]);
                min = string.Format("{0}{1}", rawVal[2], rawVal[3]);
            }
            else if (len == 3) {
                hr = string.Format("{0}{1}", "0", rawVal[0]);
                min = string.Format("{0}{1}", rawVal[1], rawVal[2]);
            }
            else if (len == 2)
            {
                min = string.Format("{0}{1}", rawVal[0], rawVal[1]);
                hr = "00";
            }
            else // len == 1
            {
                min = string.Format("{0}{1}", "0", rawVal[0]);
                hr = "00";
            }
            return BidTimeSpan.Parse(string.Format("{0}:{1}", hr, min));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var time = (BidTimeSpan)value;
            serializer.Serialize(writer, time.ToString());
            //throw new NotImplementedException();
        }
    }
}
