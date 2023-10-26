using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel
{
    class DataBasesViewModel
    {
        public ObservableCollection<DBDescription> DBDescriptions { get; set; }

        public DataBasesViewModel()
        {
            DBDescriptions = new ObservableCollection<DBDescription>();

            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №1",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });

            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
        }
    }
}
