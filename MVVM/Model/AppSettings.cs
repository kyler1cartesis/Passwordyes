using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.Core;
using Unity.Injection;

namespace Password_Manager.MVVM.Model
{
    public class AppSettings : ConfigurationSection
    {
        [ConfigurationProperty(nameof(WorkDir), DefaultValue = "")]
        public string WorkDir
        {
            get { return (string)this[nameof(WorkDir)]; }
            set { this[nameof(WorkDir)] = value; }
        }

        [ConfigurationProperty(nameof(TimeToDelete), DefaultValue = 10)]
        public int TimeToDelete
        {
            get { return (int)this[nameof(TimeToDelete)]; }
            set { this[nameof(TimeToDelete)] = value; }
        }
    }
}
