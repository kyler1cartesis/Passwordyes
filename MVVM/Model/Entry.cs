using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.Model;

public class Entry : IEntryOrFolderVM {
    public string Url { get; init; }
    public string Password { get; init; }
}