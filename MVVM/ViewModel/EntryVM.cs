using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.MVVM.ViewModel
{
    public class EntryVM : FileVM
    {
        private FolderVM? _parent;
        public string ImagePath { get; } = "pack://siteoforigin:,,,/GuiSources/Images/notes.png";
        public FolderVM? Parent { get { return _parent; } }
        public string Description { get; set; }
        public string Url { get; set; }
        public string CreateData { get; set; }

        public EntryVM(FolderVM? parent)
        {
            _parent = parent;
        }
    }
}
