using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Password_Manager.MVVM.ViewModel
{
    public class FileVM
    {
        private string _name;

        public string Name { get { return _name; } set { _name = value; } }
        public DateTime CreateDate { get; set; }

    }
}