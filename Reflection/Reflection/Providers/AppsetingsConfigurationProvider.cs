using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Reflection.Providers
{
    public class AppsetingsConfigurationProvider
    {
        public object Read(string key)
        {
            var json = File.ReadAllText(@"..\..\..\appsettings.json");
            dynamic jsonObj = JsonConvert.DeserializeObject<JObject>(json);
            return jsonObj[key];
        }

        public void Write(string key, object value)
        {
            var filePath = Path.Combine(@"..\..\..\appsettings.json");
            var json = File.ReadAllText(filePath);
            dynamic jsonObj = JsonConvert.DeserializeObject<JObject>(json);
            jsonObj[key] = null;
            if (value != null)
            {
                jsonObj[key] = value.ToString();
            }
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
    }
}
