using System;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel;

public abstract class IEntryOrFolderVM : ObservableObject {
    private string _name;

    public string Name {
        get {
            return _name;
        }
        set {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public DateTime CreateDate { get; set; }
    public string? Description { get; internal set; }
}