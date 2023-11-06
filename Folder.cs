using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Password_Manager
{
    public class Folder : File
    {
        public ObservableCollection<File> SubFiles { get; set; } = new ObservableCollection<File>();

        public void getEntries()
        {
            
        }
    }
}