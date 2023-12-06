using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.ViewModel
{
    public class FolderVM : FileVM
    {
        public string ImagePath { get; } = "pack://siteoforigin:,,,/GuiSources/Images/folder.png";

        private FolderVM? _parent;

        private ObservableCollection<FileVM> _subFiles;
        public ObservableCollection<FileVM> SubFiles
        {
            get => _subFiles;
            set { _subFiles = value; OnPropertyChanged(nameof(SubFiles)); }
        }

        public FolderVM? Parent { get { return _parent; } }

        public FolderVM(FolderVM? parent, string name) : base(name)
        {
            _parent = parent;
            _subFiles = new ObservableCollection<FileVM>();
        }

        public void RemoveFileByName(string name)
        {
            SubFiles.Remove(GetFileByName<EntryVM>(name));
        }

        private FILE GetFileByName<FILE>(string name) where FILE : FileVM
        {
            return (FILE)SubFiles.Single(file => file.Name == name && file is FILE);
        }

        public void AddFile(FileVM file)
        {
            SubFiles.Add(file);
        }

        public void FindAndChangeFileByName(string oldName, string newName, string Password, string? description, string? url, string? login)
        {
            EntryVM entryVM = GetFileByName<EntryVM>(oldName);

            entryVM.Name = newName;
            entryVM.Description = description;
            entryVM.Url = url;
            entryVM.Login = login;
        }
    }
}