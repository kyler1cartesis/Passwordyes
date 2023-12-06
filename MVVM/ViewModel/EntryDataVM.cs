using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Password_Manager.MVVM.View.ViewUtilities;
using Unity;

namespace Password_Manager.MVVM.ViewModel
{
    public class EntryDataVM : FilesEditFormVM
    {
        private MessageBoxManager _dialogManager;
        private ControlManager _controlManager;
        private IUnityContainer _container;
        private string _encryptedPassword;
        public ICommand DeleteEntryCommand { get; set; }
        public ICommand ChangeEntry { get; set; }
        public ICommand CopyPasswordCommand { get; set; }
        public string Password
        {
            set
            {
                IPasswordSupplier sup = _container.Resolve<IPasswordSupplier>();
                sup.SetPassword(value);
            }
        }
        public string? Login { get; set; }
		public string? Description { get; set; }
		public string? URL { get; set; }

		public EntryDataVM(DataBaseContextVM contextVM, string name, string password, string? description, string? url, string? login, IUnityContainer container) : base(contextVM)
        {
            _dialogManager = new MessageBoxManager();
            _controlManager = new ControlManager();
            _container = container;
            _encryptedPassword = password;
            Name = name;
            Login = login;
            Description = description;
            URL = url;

            Password = ModelAPI.DecryptEntryPassword(_encryptedPassword);

            DeleteEntryCommand = new RelayCommand(DeleteEntry, CanDeleteEntry);
            ChangeEntry = new RelayCommand(ShowChangeEntryForm, CanShowChangeEntryForm);
            CopyPasswordCommand = new RelayCommand(CopyPassword);
        }

		private bool CanDeleteEntry(object obj)
		{
			return true;
		}

		private void DeleteEntry(object obj)
		{
            var answer = _dialogManager.ShowMessageBox("Вы уверены, что хотите удалить запись: " + Name + " ?",
                                                        "удаление БД",
                                                        MessageBoxImage.Question);

            if (answer == MessageBoxResult.No) return;

            FolderVM currentFolder = GetCurrentFolder();

            currentFolder.RemoveFileByName(Name);

            CloseForm(new object());
		}

        private bool CanShowChangeEntryForm(object obj)
        {
            return true;
        }

        private void ShowChangeEntryForm(object obj)
        {
            ChangeEntryFormView changeEntryView = _controlManager.CreateControl<ChangeEntryFormView>();
            IUnityContainer container = _controlManager.RegisterControl(changeEntryView);

            EntryDataView entryDataForm = GetCurrentViewAsUserControl<EntryDataView>();

            ChangeEntryFormVM changeFormVM = CreateChangeEntryFormVM(entryDataForm, container);

            _controlManager.BindDataContextToControl(changeEntryView, changeFormVM);

            SetDBContextCurrentView(changeEntryView);
        }

        private ChangeEntryFormVM CreateChangeEntryFormVM(EntryDataView entryDataForm, IUnityContainer container)
        {
            return new ChangeEntryFormVM(Name, _encryptedPassword, Description, URL, Login, DBContext, entryDataForm, container);
        }

        private void CopyPassword(object obj)
        {
            return;
            ModelAPI.CopyPasswordToClipBoard(_encryptedPassword);
        }
    }
}
