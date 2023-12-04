using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.MVVM.ViewModel
{
    public class EntryVM : FileVM
    {
        public string ImagePath { get; } = "pack://siteoforigin:,,,/GuiSources/Images/notes.png";

        private FolderVM? _parent;
        public FolderVM? Parent { get { return _parent; } }

        private string? _description;
        public string? Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        private string? _url;
        public string? Url
        {
            get => _url;
            set { _url = value; OnPropertyChanged(nameof(Url)); }
        }

        private string? _password;
        public string? Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public EntryVM(FolderVM? parent, string name, string? description, string? url) : base(name)
        {
            _parent = parent;
            _description = description;
            _url = url;
        }

        public EntryVM(FolderVM? parent, string name) : base(name)
        {
            _parent = parent;
            _description = string.Empty;
            _url = string.Empty;
        }
    }
}
