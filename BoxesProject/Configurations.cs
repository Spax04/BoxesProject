using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesProject
{
    public class Configurations
    {
        public ConfigData Data { get; set; }

        var currentDir = Environment.CurrentDirectory;
        string fileName = "projectConfig.json";
        var configPath = Path.Combine(currentDir, fileName);
        var config = File.ReadAllText(configPath);
        Data = JsonConvert.DeserializeObject<ConfigData>(config);
    }

    public class ConfigData
    {
        public int max_expire_days { get; set; }
        public int max_boxes { get; set; }
        public int min_boxes { get; set; }

    }
}
