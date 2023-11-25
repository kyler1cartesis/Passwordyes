using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel
{
    public class FileVM : ObservableObject
    {
        private string _name;

        public string Name 
        { 
            get 
            { 
                return _name; 
            } 
            set 
            { 
                _name = value;
                OnPropertyChanged("Name");
            } 
        }
        public DateTime CreateDate { get; set; }

    }
}