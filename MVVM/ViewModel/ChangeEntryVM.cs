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
    public class ChangeEntryVM : FilesEditForm
    {
        private IUnityContainer _container;
        public IUnityContainer Container
        {
            set => _container = value;
        }
        public EntryDataView EntryData { get; set; }
        public ICommand ChangeEntryCommand { get; set; }
        public ICommand CancelEditCommand { get; set; }
        public string Password
        {
            get
            {
                IPasswordSupplier supl = _container.Resolve<IPasswordSupplier>();
                return supl.GetPassword();
            }
        }
        public string Description { get; set; }
        public string URL { get; set; }
        public string OldName {  get; set; }

        public ChangeEntryVM() : base()
        {
            ChangeEntryCommand = new RelayCommand(ChangeEntry);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        private void ChangeEntry(object obj)
        {
            //ModelAPI.ValidateEntryPassword(Password);
            //ModelAPI.ValidateEntryDescription(Description);
            //ModelAPI.ValidateFileName(Name);
            //ModelAPI.VaildateEntruURL(URL);


            //ModelAPI.ChangeEntry(OldName, Name, Description, URL, Password);
            //DBContext.CurrentSubFiles = ModelAPI.UpdateFileList();

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

        private void CancelEdit(object obj)
        {
            DBContext.CurrentView = EntryData;
        }
    }
}
