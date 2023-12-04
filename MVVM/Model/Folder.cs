using System.Collections.Generic;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.Model;

public class Folder : IEntryOrFolderVM {
    private List<IEntryOrFolderVM>? children = null;
    
    public List<IEntryOrFolderVM>? Contents { get; set; }
    internal IEntryOrFolderVM this[int index] { get => children![index]; set => children![index] = value; }
    internal int EntriesCount => children is not null ? children.Count : 0;

    internal void Add(IEntryOrFolderVM obj) {
        children ??= new();
        children.Add(obj);
    }
}