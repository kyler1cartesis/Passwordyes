using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.View;

namespace Password_Manager.MVVM.ViewModel
{
    public class EntryDataVM : FilesEditForm
    {
        public ICommand DeleteEntryCommand { get; set; }
        public ICommand ChangeEntry { get; set; }
        public string Password { get; set; }
		public string Description { get; set; }
		public string URL { get; set; }

		public EntryDataVM() : base()
        {
			DeleteEntryCommand = new RelayCommand(DeleteEntry, CanDeleteEntry);
            ChangeEntry = new RelayCommand(ShowChangeEntryForm, CanShowChangeEntryForm);
        }

		private bool CanDeleteEntry(object obj)
		{
			return true;
		}

		private void DeleteEntry(object obj)
		{
            var subFiles = DBContext.CurrentSubFiles.Where((file) =>
            {
                return file is not EntryVM || file.Name != Name;
            });
			var subFilesWithoutCurrentEntry = new ObservableCollection<FileVM>(subFiles);
			DBContext.CurrentSubFiles = subFilesWithoutCurrentEntry;
			(DBContext.CurrentFolder as FolderVM).SubFiles = subFilesWithoutCurrentEntry;

			DBContext.ClosePage();
		}

        private bool CanShowChangeEntryForm(object obj)
        {
            return true;
        }

        private void ShowChangeEntryForm(object obj)
        {
            ChangeEntryVM changeForm = new ChangeEntryVM();
            changeForm.DBContext = DBContext;
            
            changeForm.Name = Name;
            changeForm.Description = Description;
            changeForm.URL = URL;
            changeForm.OldName = Name;

            DBContext.CurrentView = new ChangeEntryView(changeForm);
        }
    }
}
