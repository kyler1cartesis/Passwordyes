using System;
using System.Text.Json.Serialization;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel;

[JsonDerivedType(typeof(Entry), typeDiscriminator: "entry")]
[JsonDerivedType(typeof(Folder), typeDiscriminator: "folder")]
public abstract class IEntryOrFolderVM : ObservableObject {
    private string _name;

    internal string Name {
        get {
            return _name;
        }
        set {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
}