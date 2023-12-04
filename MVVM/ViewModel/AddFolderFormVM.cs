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
    public class AddFolderFormVM : FilesEditFormVM
    {
        public ICommand CreateFolderCommand { get; set; }
        public AddFolderFormVM(DataBaseContextVM contextVM) : base(contextVM)
        {
            CreateFolderCommand = new RelayCommand(CreateFolder);
        }

        private void CreateFolder(object obj)
        {
            FolderVM currentFolder = GetCurrentFolder();

            FolderVM folder = CreateFolder(currentFolder);

            currentFolder.AddFile(folder);
            
            CloseForm(new object());
        }

        private FolderVM CreateFolder(FolderVM parentFolder)
        {
            return new FolderVM(parentFolder, Name);
        }
    }
}
