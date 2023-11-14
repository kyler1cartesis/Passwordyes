using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Password_Manager.MVVM.Model;

namespace Password_Manager
{
    public class FolderVM : File
    {
        private FolderVM? _parent;
        public ObservableCollection<File> SubFiles { get; set; } = new ObservableCollection<File>();
        public string ImagePath { get; } = "pack://siteoforigin:,,,/GuiSources/Images/folder.png";

        public FolderVM? Parent { get { return _parent; } }

        public FolderVM(FolderVM? parent)
        {
            _parent = parent;
        }

        public void getEntries()
        {
            
        }
    }
}