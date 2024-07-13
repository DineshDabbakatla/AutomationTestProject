using System;
using Newtonsoft.Json;
using System.IO;

namespace FrameworkLayer
{
    public class ConfigReader
    {
        public static TestSettings GetConfig(string configPath)
        {
            string config = File.ReadAllText(configPath);

            return JsonConvert.DeserializeObject<TestSettings>(config);
        }
    }
}
