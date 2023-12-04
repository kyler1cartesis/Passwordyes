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
    public class AddEntryVMForm : FilesEditForm
    {
        private IUnityContainer _container;
        public ICommand CreateEntryCommand { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
        public string? Password
        {
            get
            {
                IPasswordSupplier supplier = _container.Resolve<IPasswordSupplier>();
                return supplier.GetPassword();
            }
        }

        public AddEntryVMForm(DataBaseContextVM contextVM, IUnityContainer container) : base(contextVM)
        {
            _container = container;

            CreateEntryCommand = new RelayCommand(AddEntry);
        }

        private void AddEntry(object obj)
        {
            FolderVM currentFolder = GetCurrentFolder();

            EntryVM entry = CreateEntry(currentFolder, Name, Description, URL);

            currentFolder.AddFile(entry);

            CloseForm(new object());
        }
    }
}
