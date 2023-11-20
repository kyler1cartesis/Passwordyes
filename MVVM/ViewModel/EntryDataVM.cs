using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel
{
    public class EntryDataVM : FilesEditForm
    {
        public ICommand DeleteEntryCommand { get; set; }
		public string Password { get; set; }
		public string Description { get; set; }
		public string URL { get; set; }

		public EntryDataVM()
		{
			DeleteEntryCommand = new RelayCommand(DeleteEntry, CanDeleteEntry);
		}

		private bool CanDeleteEntry(object obj)
		{
			return true;
		}

		private void DeleteEntry(object obj)
		{
			var subFiles = DBContext.CurrentSubFiles.Where(file => file.Name != Name);
			var subFilesWithoutCurrentEntry = new ObservableCollection<File>(subFiles);
			DBContext.CurrentSubFiles = subFilesWithoutCurrentEntry;
			(DBContext.CurrentFolder as FolderVM).SubFiles = subFilesWithoutCurrentEntry;

			DBContext.ClosePage();
		}
	}
}
