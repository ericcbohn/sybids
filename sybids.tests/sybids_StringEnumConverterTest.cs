using System;
using Xunit;

namespace sybids.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}

using Xunit;
using sybids.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace sybids.UnitTests.Models {
    [TestFixture]
    public class sybids_StringEnumConverterTest {
        public class SampleEntity {
            [JsonProperty("base"), JsonConverter(typeof(StringEnumConverter))]
            public Airport Base { get; set; }
        }

        [Test]
        public void DeserializeAirportTest() {
            Dictionary<string, Airport> expectations = GetAirportMapping();

            foreach (var kv in expectations) {
                var jsonString = string.Format("{{ \"base\" : \"{0}\" }}", kv.Key);
                var deserializedObject = JsonConvert.DeserializeObject<SampleEntity>(jsonString);

                Assert.AreEqual(kv.Value, deserializedObject.Base);
            }
        }

        [Test]
        public void SerializeAirportTest() {
            Dictionary<string, Airport> expectations = GetAirportMapping();

            foreach (var kv in expectations) {
                var obj = new SampleEntity { Base = kv.Value };

                var expectedJsonString  = string.Format("{{\"base\":\"{0}\"}}", kv.Key);
                var actualJsonString = JsonConvert.SerializeObject(obj);

                Assert.AreEqual(expectedJsonString, actualJsonString);
            }
        }

        private Dictionary<string, Airport> GetAirportMapping() {
            return new Dictionary<string, Airport>() {
                { "CUN", Airport.CUN },
                { "DEN", Airport.DEN },
                { "IFP", Airport.IFP },
                { "JFK", Airport.JFK },
                { "LAS", Airport.LAS },
                { "LAX", Airport.LAX },
                { "MCO", Airport.MCO },
                { "MSP", Airport.MSP },
                { "RSW", Airport.RSW },
                { "ZIH", Airport.ZIH }
            };
        }
    }
}
