using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.MVVM.Model
{
    public static class ConfigUtil
    {
        public static Configuration AppConf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    }
}
