using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel
{
    public class AddEntryVM : ObservableObject
    {
        public DataBaseContextVM DBContext { get; set; }
        public ICommand CreateEntryCommand { get; set; }

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
        public string Password { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

        public AddEntryVM()
        {
            CreateEntryCommand = new RelayCommand(CreateEntry, CanCreateEntry);
        }

        private bool CanCreateEntry(object obj)
        {
            return true;
            if ((Password == null) || (Description == null) || (URL == null) || (Name == null))
            {
                return false;
            }
            else
                return true;
        }

        private void CreateEntry(object obj)
        {
            FolderVM currentFolder = DBContext.CurrentFolder as FolderVM;
            EntryVM entry = new EntryVM(currentFolder.Parent);
            entry.Name = Name;
            entry.Description = Description;
            entry.Url = URL;
            var newSubFiles = DBContext.CurrentSubFiles;
            newSubFiles.Add(entry);
            DBContext.CurrentSubFiles = newSubFiles;
        }
    }
}
