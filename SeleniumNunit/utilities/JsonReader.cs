using System;
using Newtonsoft.Json.Linq;

namespace SeleniumNunitFramework.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }

        public String ExtractData(String key)
        {
            String jsonString = File.ReadAllText("utilities/testdata.json");
            var testdata = JToken.Parse(jsonString);
            return testdata.SelectToken(key).Value<String>();
        }
    }
}

