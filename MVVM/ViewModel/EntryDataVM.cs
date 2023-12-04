using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Password_Manager.MVVM.View.ViewUtilities;
using Unity;

namespace Password_Manager.MVVM.ViewModel;

public class EntryDataVM : FilesEditForm {
    public ICommand DeleteEntryCommand { get; set; }
    public ICommand ChangeEntry { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public string URL { get; set; }

    public EntryDataVM () : base() {
        DeleteEntryCommand = new RelayCommand(DeleteEntry, CanDeleteEntry);
        ChangeEntry = new RelayCommand(ShowChangeEntryForm, CanShowChangeEntryForm);
    }

    private bool CanDeleteEntry (object obj) {
        return true;
    }

    private void DeleteEntry (object obj) {
        var answer = MessageBoxManager.ShowMessageBox("Вы уверены, что хотите удалить запись: " + Name + " ?",
                                         "удаление БД",
                                         MessageBoxImage.Question);

        if (answer == MessageBoxResult.No) return;

        //ModelAPI.RemoveFileByName(Name);
        //DBContext.CurrentSubFiles = ModelAPI.UpdateFileList();

        var subFiles = DBContext.CurrentSubFiles.Where((file) => {
            return file is not EntryVM || file.Name != Name;
        });
        var subFilesWithoutCurrentEntry = new ObservableCollection<IEntryOrFolderVM>(subFiles);
        DBContext.CurrentSubFiles = subFilesWithoutCurrentEntry;
        (DBContext.CurrentFile as FolderVM).SubFiles = subFilesWithoutCurrentEntry;

        DBContext.ClosePage();
    }

    private bool CanShowChangeEntryForm (object obj) {
        return true;
    }

    private void ShowChangeEntryForm (object obj) {
        ChangeEntryView changeEntryView = new ChangeEntryView();
        IUnityContainer container = ControlRegister.RegisterControl(changeEntryView);

        ChangeEntryVM changeForm = new ChangeEntryVM();
        changeForm.DBContext = DBContext;

        changeForm.EntryData = (EntryDataView) DBContext.CurrentView;
        changeForm.Name = Name;
        changeForm.Description = Description;
        changeForm.URL = URL;
        changeForm.OldName = Name;
        changeForm.Container = container;
        changeEntryView.DataContext = changeForm;

        DBContext.CurrentView = changeEntryView;

    }
}
