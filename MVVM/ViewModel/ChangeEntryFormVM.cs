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

namespace Password_Manager.MVVM.ViewModel
{
    public class ChangeEntryFormVM : FilesEditFormVM
    {
        private IUnityContainer _container;
        public EntryDataView EntryDataForm { get; set; }
        public ICommand ChangeEntryCommand { get; set; }
        public ICommand CancelEditCommand { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
        public string OldName {  get; set; }
        public string Password
        {
            get
            {
                IPasswordSupplier supl = _container.Resolve<IPasswordSupplier>();
                return supl.GetPassword();
            }
        }

        public ChangeEntryFormVM(string name, string? description, string? url, DataBaseContextVM? contextVM,
                                EntryDataView entryData, IUnityContainer container) : base(contextVM)
        {
            _container = container;
            Name = name;
            Description = description;
            URL = url;
            OldName = name;
            EntryDataForm = entryData;

            ChangeEntryCommand = new RelayCommand(ChangeEntry);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        private void ChangeEntry(object obj)
        {
            FolderVM currentFolder = GetCurrentFolder();

            currentFolder.FindAndChangeFileByName(OldName, Name, Description, URL);

            CloseForm(new object());
        }

        private void CancelEdit(object obj)
        {
            SetDBContextCurrentView(EntryDataForm);
        }
    }
}
