namespace Password_Manager.MVVM.ViewModel;

public class EntryVM : IEntryOrFolderVM {
    private FolderVM? _parent;
    public string ImagePath { get; } = "pack://siteoforigin:,,,/GuiSources/Images/notes.png";
    public FolderVM? Parent { get { return _parent; } }
    public string Description { get; set; }
    public string Url { get; set; }

    public EntryVM (FolderVM? parent) {
        _parent = parent;
    }
}
