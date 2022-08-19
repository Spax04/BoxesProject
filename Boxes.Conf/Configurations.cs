using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Conf
{
    public class Configurations
    {
        public static Configurations _instans;
        public static Configurations Instans
        {
            get
            {
                if (_instans == null)
                    _instans = new Configurations();
                return _instans;
            }
        }

        public ConfigData Data { get; set; }

        private Configurations()
        {
            var currentDir = Environment.CurrentDirectory;
            var fileName = "config.json";
            var configPath = Path.Combine(currentDir, fileName);
            var raw = File.ReadAllText(configPath);
            Data = JsonConvert.DeserializeObject<ConfigData>(raw);
        }
    }
}
