using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.MVVM.Model
{
    public class DBDescription
    {
        public string DataBaseName { get; set; }
        public string Status { get; set; }
        public DateTime DataBaseLastOpenDate { get; set; }
        public DateTime DataBaseCreateDate { get; set; }

        public DBDescription(string dataBaseName, DateTime dataBaseCreateDate)
        {
            DataBaseName = dataBaseName;
            DataBaseCreateDate = dataBaseCreateDate;
        }

        public DBDescription()
        {
        }
    }
}
