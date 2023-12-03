using System.Windows.Input;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel;

public class AddFolderVM : FilesEditForm {
    public ICommand CreateFolderCommand { get; set; }
    public AddFolderVM () : base() {
        CreateFolderCommand = new RelayCommand(CreateFolder);
    }



    private void CreateFolder (object obj) {
        //ModelAPI.CreatNewFolder(Name);
        //DBContext.CurrentSubFiles = ModelAPI.UpdateFileList();

        FolderVM currentFolder = DBContext.CurrentFile as FolderVM;
        FolderVM folder = new FolderVM(currentFolder);

        folder.Name = Name;

        var newSubFiles = DBContext.CurrentSubFiles;
        newSubFiles.Add(folder);
        DBContext.CurrentSubFiles = newSubFiles;
        DBContext.ClosePage();
    }
}
