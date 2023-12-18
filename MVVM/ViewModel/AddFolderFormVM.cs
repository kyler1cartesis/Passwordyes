using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View.ViewUtilities;

namespace Password_Manager.MVVM.ViewModel
{
    public class AddFolderFormVM : FilesEditFormVM
    {
        private MessageBoxManager _dialogManager;
        public ICommand CreateFolderCommand { get; set; }
        public AddFolderFormVM(DataBaseContextVM contextVM) : base(contextVM)
        {
            _dialogManager = new MessageBoxManager();

            CreateFolderCommand = new RelayCommand(CreateFolder);
        }

        private void CreateFolder(object obj)
        {
            FolderVM currentFolder = GetCurrentFolder();

            FolderVM folder = CreateFolder(currentFolder);

            bool isValid = currentFolder.ValidateNameOfFile<FolderVM>(folder.Name);
            if (!isValid)
            {
                _dialogManager.ShowMessageBox("Имя пустое или уже существует!",
                                                        "ошибка данных",
                                                        MessageBoxImage.Error);
                return;
            }

            currentFolder.AddFile(folder);
            
            CloseForm(new object());
        }

        private FolderVM CreateFolder(FolderVM parentFolder)
        {
            return new FolderVM(parentFolder, Name);
        }
    }
}
