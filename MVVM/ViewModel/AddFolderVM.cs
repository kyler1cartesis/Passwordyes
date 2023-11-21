using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel
{
    public class AddFolderVM : FilesEditForm
    {
        public ICommand CreateFolderCommand { get; set; }
        public AddFolderVM() : base()
        {
            CreateFolderCommand = new RelayCommand(CreateFolder, CanCreateFolder);
        }

        private bool CanCreateFolder(object obj)
        {
            return (Name != null);
        }

        private void CreateFolder(object obj)
        {
            FolderVM currentFolder = DBContext.CurrentFolder as FolderVM;
            FolderVM folder = new FolderVM(currentFolder);

            folder.Name = Name;

            var newSubFiles = DBContext.CurrentSubFiles;
            newSubFiles.Add(folder);
            DBContext.CurrentSubFiles = newSubFiles;
            DBContext.ClosePage();
        }
    }
}
