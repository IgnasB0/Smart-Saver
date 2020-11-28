using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API
{
    public class ConfigHelper
    {
        private ConfigHelper() { }
        public static ConfigHelper Instance()
        {
            if (_instance == null)
            {
                _instance = new ConfigHelper();
            }
            return _instance;
        }
        public IConfiguration Configuration { get; set; }
        private static ConfigHelper _instance = null;
    }
}
