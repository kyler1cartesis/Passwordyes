using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel
{
    public class EntryVM : File
    {
        private FolderVM? _parent;
        public string ImagePath { get; } = "pack://siteoforigin:,,,/GuiSources/Images/notes.png";
        public FolderVM? Parent { get { return _parent; } }
        public string Description { get; }
        public string Url { get; }
        public string CreateData { get; }

        public EntryVM(FolderVM? parent)
        {
            _parent = parent;
        }
    }
}
