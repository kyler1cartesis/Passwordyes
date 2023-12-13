using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel
{
    public class FilesEditFormVM : ObservableObject
    {
        public RelayCommand CloseFormCommand { get; set; }
        public DataBaseContextVM? DBContext { get; set; }

        protected string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public FilesEditFormVM(DataBaseContextVM? contextVM) 
        { 
            _name = string.Empty;
            DBContext = contextVM;

            CloseFormCommand = new RelayCommand(CloseForm);
        }

        protected FolderVM GetCurrentFolder()
        {
            FolderVM? currentFolder = DBContext?.CurrentFile as FolderVM;

            if (currentFolder == null) throw new NullReferenceException("Current folder was null while create entry");

            return currentFolder;
        }

        protected T GetCurrentViewAsUserControl<T>() where T : UserControl
        {
            T? form = (T?)DBContext?.CurrentView;

            if (form == null) throw new NullReferenceException("CurrentView was null while create form");

            return form;
        }

        protected void CloseForm(object obj)
        {
            DBContext?.ClosePage();
        }

        protected void SetDBContextCurrentView<FORM>(FORM filesEditForm) where FORM : UserControl
        {
            if (DBContext != null)
                DBContext.CurrentView = filesEditForm;
            else
                CloseForm(new object());
        }

        protected EntryVM CreateEntry(FolderVM parentFolder, string Name, byte[] password, string? Description, string? URL, string? login)
        {
            return new EntryVM(parentFolder, Name, password, Description, URL, login);
        }
    }
}
