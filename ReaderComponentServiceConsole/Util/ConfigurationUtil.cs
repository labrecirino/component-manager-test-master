using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderComponentService.Util
{
    static class ConfigurationUtil
    {
        public static string GetSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string value = appSettings[key];
            return value; 
        }
    }
}
