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
        public ICommand CreateEntryCommand { get; set; }
        public ICommand GeneratePasswordCommand { get; set; }
        private byte[] _ecnryptPassword;
        public string? Description { get; set; }
        public string? URL { get; set; }
        public string? Login { get; set; }
        public string Password
        {
            set
            {
                IPasswordSupplier supl = _container.Resolve<IPasswordSupplier>();
                supl.SetPassword(value);
            }
            get
            {
                IPasswordSupplier supplier = _container.Resolve<IPasswordSupplier>();
                return supplier.GetPassword();
            }
        }

        public AddEntryFormVM(DataBaseContextVM contextVM, IUnityContainer container) : base(contextVM)
        {
            _container = container;
            _ecnryptPassword = [];

            CreateEntryCommand = new RelayCommand(AddEntry);
            GeneratePasswordCommand = new RelayCommand(GeneratePassword);
        }

        private void AddEntry(object obj)
        {
            FolderVM currentFolder = GetCurrentFolder();

            _ecnryptPassword = ModelAPI.EncryptEntryPassword(Password);

            EntryVM entry = CreateEntry(currentFolder, Name, _ecnryptPassword, Description, URL, Login);

            currentFolder.AddFile(entry);

            CloseForm(new object());
        }
        protected override void SwitchPasswordVisibility(object obj)
        {
            if (IsShown)
            {
                PasswordToShow = Password;
            }
            else
            {
                Password = PasswordToShow;
                PasswordToShow = string.Empty;
            }
        }

        private void GeneratePassword(object obj)
        {
            if (IsShown)
            {
                PasswordToShow = GetRandomString();
            }
            else
            {
                Password = GetRandomString();
            }
        }
    }
}
