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
    public class AddEntryVM : FilesEditForm
    {
        public ICommand CreateEntryCommand { get; set; }
        public Tuple<string, string> Password { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

        public AddEntryVM() : base()
        {
            CreateEntryCommand = new RelayCommand(CreateEntry, CanCreateEntry);
        }

        private bool CanCreateEntry(object obj)
        {
            //ModelAPI.ValidateEntryPassword(Password);
            //ModelAPI.ValidateEntryDescription(Description);
            //ModelAPI.ValidateFileName(Name);
            //ModelAPI.VaildateEntruURL(URL);
            if ((Password == null) || (Description == null) || (URL == null) || (Name == null))
            {
                return false;
            }
            else
                return true;
        }

        private void CreateEntry(object obj)
        {
            //ModelAPI.CreateNewEntry(Name, Description, URL, Password.Item1
            //DBContext.CurrentSubFiles = ModelAPI.UpdateFileList();

            FolderVM currentFolder = DBContext.CurrentFile as FolderVM;

            EntryVM entry = new EntryVM(currentFolder);

            entry.Name = Name;
            entry.Description = Description;
            entry.Url = URL;

            var newSubFiles = DBContext.CurrentSubFiles;
            newSubFiles.Add(entry);
            DBContext.CurrentSubFiles = newSubFiles;
            DBContext.ClosePage();
        }
    }
}
