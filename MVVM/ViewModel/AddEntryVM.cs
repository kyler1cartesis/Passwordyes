using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Unity;

namespace Password_Manager.MVVM.ViewModel
{
    public class AddEntryVM : FilesEditForm
    {
        private IUnityContainer _container;
        public IUnityContainer Container
        {
            set { _container = value; }
        }
        public ICommand CreateEntryCommand { get; set; }
        public string Password
        {
            get
            {
                IPasswordSupplier supplier = _container.Resolve<IPasswordSupplier>();
                return supplier.GetPassword();
            }
        }
        public string Description { get; set; }
        public string URL { get; set; }

        public AddEntryVM() : base()
        {
            CreateEntryCommand = new RelayCommand(CreateEntry);
        }

        private void CreateEntry(object obj)
        {
            //ModelAPI.CreateNewEntry(Name, Description, URL, Password)
            //DBContext.CurrentSubFiles = ModelAPI.UpdateFileList();

            FolderVM currentFolder = DBContext.CurrentFile as FolderVM;

            EntryVM entry = new EntryVM(currentFolder);

            entry.Name = Name;
            entry.Description = Description;
            entry.Url = URL;

            var newSubFiles = DBContext.CurrentSubFiles;
            newSubFiles.Add(entry);
            DBContext.CurrentSubFiles = newSubFiles;
            DBContext.ClosePage();
        }
    }
}
