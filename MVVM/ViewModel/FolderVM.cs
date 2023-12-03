﻿using System.Collections.ObjectModel;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager;

public class FolderVM : FileVM {
    private FolderVM? _parent;
    public ObservableCollection<FileVM> SubFiles { get; set; } = new();
    public string ImagePath { get; } = "pack://siteoforigin:,,,/GuiSources/Images/folder.png";

    public FolderVM? Parent { get { return _parent; } }

    public FolderVM (FolderVM? parent) {
        _parent = parent;
    }
}