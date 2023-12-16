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
        public override string ImagePath { get => folder_path; }

        private ObservableCollection<FileVM> _subFiles;
        public ObservableCollection<FileVM> SubFiles
        {
            get => _subFiles;
            set { _subFiles = value; OnPropertyChanged(nameof(SubFiles)); }
        }

        public FolderVM(FolderVM? parent, string name) : base(parent, name)
        {
            _parent = parent;
            _subFiles = new ObservableCollection<FileVM>();
        }

        public FolderVM() : base()
        {
            _parent = null;
            _subFiles = new ObservableCollection<FileVM>();
        }

        public void RemoveFileByName<FILE>(string name) where FILE : FileVM
        {
            SubFiles.Remove(GetFileByName<FILE>(name));
        }

        private FILE GetFileByName<FILE>(string name) where FILE : FileVM
        {
            return (FILE)SubFiles.Single(file => file.Name == name && file is FILE);
        }

        public void AddFile(FileVM file)
        {
            SubFiles.Add(file);
        }

        public void FindAndChangeFileByName(string oldName, string newName, byte[] Password, string? description, string? url, string? login)
        {
            EntryVM entryVM = GetFileByName<EntryVM>(oldName);

            entryVM.Name = newName;
            entryVM.Description = description;
            entryVM.Url = url;
            entryVM.Login = login;
            entryVM.Password = Password;
        }
    }
}