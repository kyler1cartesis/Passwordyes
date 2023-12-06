using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Unity;

namespace Password_Manager.MVVM.ViewModel
{
    public class AddEntryFormVM : FilesEditFormVM
    {
        private IUnityContainer _container;
        private string _ecnryptPassword;
        public ICommand CreateEntryCommand { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
        public string? Login { get; set; }
        public string Password
        {
            get
            {
                IPasswordSupplier supplier = _container.Resolve<IPasswordSupplier>();
                return supplier.GetPassword();
            }
        }

        public AddEntryFormVM(DataBaseContextVM contextVM, IUnityContainer container) : base(contextVM)
        {
            _container = container;
            _ecnryptPassword = string.Empty;

            CreateEntryCommand = new RelayCommand(AddEntry);
        }

        private void AddEntry(object obj)
        {
            FolderVM currentFolder = GetCurrentFolder();

            _ecnryptPassword = ModelAPI.EncryptEntryPassword(Password);

            EntryVM entry = CreateEntry(currentFolder, Name, _ecnryptPassword, Description, URL, Login);

            currentFolder.AddFile(entry);

            CloseForm(new object());
        }
    }
}
