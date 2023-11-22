using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.Core;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Password_Manager.MVVM.ViewModel
{
    public class ChangeEntryVM : FilesEditForm
    {
        public ICommand ChangeEntryCommand { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string OldName {  get; set; }

        public ChangeEntryVM() : base()
        {
            ChangeEntryCommand = new RelayCommand(ChangeEntry, CanChangeEntry);
        }

        private bool CanChangeEntry(object obj)
        {
            if ((Password == null) || (Description == null) || (URL == null) || (Name == null))
            {
                return false;
            }
            else
                return true;
        }

        private void ChangeEntry(object obj)
        {
            FolderVM currentFolder = DBContext.CurrentFile as FolderVM;
            EntryVM entry = new EntryVM(currentFolder);

            entry.Name = Name;
            entry.Description = Description;
            entry.Url = URL;

            var subFiles = DBContext.CurrentSubFiles.Where((file) =>
            {
                return file is not EntryVM || file.Name != OldName;
            });
            var subFilesWithoutCurrentEntry = new ObservableCollection<FileVM>(subFiles)
            {
                entry
            };
            DBContext.CurrentSubFiles = subFilesWithoutCurrentEntry;
            currentFolder.SubFiles = subFilesWithoutCurrentEntry;

            DBContext.ClosePage();
        }
    }
}
