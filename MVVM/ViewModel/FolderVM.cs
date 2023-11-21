using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager
{
    public class FolderVM : FileVM
    {
        private FolderVM? _parent;
        public ObservableCollection<FileVM> SubFiles { get; set; } = new ObservableCollection<FileVM>();
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