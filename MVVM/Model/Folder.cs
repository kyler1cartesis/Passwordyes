using System.Collections.Generic;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.Model;

public class Folder : IEntryOrFolderVM {
    private List<IEntryOrFolderVM>? children = null;
    
    public int EntriesCount => children is not null ? children.Count : 0;
}