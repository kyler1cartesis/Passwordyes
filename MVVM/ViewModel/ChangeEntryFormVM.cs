using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.Core;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Unity;
using static Unity.Storage.RegistrationSet;
using System.Diagnostics;

namespace Password_Manager.MVVM.ViewModel
{
    public class ChangeEntryFormVM : FilesEditFormVM
    {
        private IUnityContainer _container;
        private byte[] _encryptedPassword;
        private ControlManager _controlManager;
        public EntryDataView EntryDataForm { get; set; }
        public ICommand ChangeEntryCommand { get; set; }
        public ICommand CancelEditCommand { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
        public string? Login { get; set; }
        public string OldName {  get; set; }
        public string Password
        {
            set
            {
                IPasswordSupplier supl = _container.Resolve<IPasswordSupplier>();
                supl.SetPassword(value);
            }
            get
            {
                IPasswordSupplier supl = _container.Resolve<IPasswordSupplier>();
                return supl.GetPassword();
            }
        }

        public ChangeEntryFormVM(string name, byte[] password, string? description, string? url, string? login, DataBaseContextVM? contextVM,
                                EntryDataView entryData, IUnityContainer container) : base(contextVM)
        {
            _container = container;
            _encryptedPassword = password;
            _controlManager = new ControlManager();
            Name = name;
            Login = login;
            Description = description;
            URL = url;
            OldName = name;
            EntryDataForm = entryData;

            Password = ModelAPI.DecryptEntryPassword(password);

            ChangeEntryCommand = new RelayCommand(ChangeEntry);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        private void ChangeEntry(object obj)
        {
            FolderVM currentFolder = GetCurrentFolder();

            _encryptedPassword = ModelAPI.EncryptEntryPassword(Password);

            currentFolder.FindAndChangeFileByName(OldName, Name, _encryptedPassword, Description, URL, Login);

            UpdateEntryDataFormValues();

            CancelEdit(new());
        }

        private void CancelEdit(object obj)
        {
            SetDBContextCurrentView(EntryDataForm);
        }

        private void UpdateEntryDataFormValues()
        {
            EntryDataView entryDataView = _controlManager.CreateControl<EntryDataView>();
            IUnityContainer container = _controlManager.RegisterControl(entryDataView);

            EntryDataVM entryDataVM = CreateEntryDataFormVM(container);

            _controlManager.BindDataContextToControl(entryDataView, entryDataVM);
            EntryDataForm = entryDataView;
        }

        private EntryDataVM CreateEntryDataFormVM(IUnityContainer container)
        {
            if (DBContext == null) throw new NullReferenceException("DBContext was null while cancel change form");

            return new EntryDataVM(DBContext, Name, _encryptedPassword, Description, URL, Login, container);
        }
    }
}
