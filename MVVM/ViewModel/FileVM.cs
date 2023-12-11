using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel
{
    [JsonDerivedType(typeof(EntryVM), typeDiscriminator: "entry")]
    [JsonDerivedType(typeof(FolderVM), typeDiscriminator: "folder")]
    public class FileVM : ObservableObject
    {
        public static string folder_path = "pack://siteoforigin:,,,/GuiSources/Images/folder.png";
        public static string entry_path = "pack://siteoforigin:,,,/GuiSources/Images/notes.png";
       
        [Newtonsoft.Json.JsonIgnore]
        public virtual string ImagePath { get => ""; }
        protected string _name;

        public string Name 
        { 
            get 
            { 
                return _name; 
            } 
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            } 
        }
        protected FolderVM? _parent;
        public FolderVM? Parent { get { return _parent; } set => _parent = value; }
        public DateTime CreateDate { get; set; }

        public FileVM(FolderVM? parent, string name)
        {
            _parent = parent;
            _name = name;
        }

        public FileVM()
        {
            _parent = null;
            _name = string.Empty;
        }

    }
}