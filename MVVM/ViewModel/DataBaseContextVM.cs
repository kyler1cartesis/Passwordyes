﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Unity;

namespace Password_Manager.MVVM.ViewModel;

public class DataBaseContextVM : ObservableObject {
    public ICommand SelectFile { get; set; }
    public ICommand GoToUpFolder { get; set; }
    public ICommand NewEntry { get; set; }
    public ICommand NewFolder { get; set; }
    public ICommand ExitDB { get; set; }



    private ObservableCollection<FileVM> _currentSubFiles;
    public ObservableCollection<FileVM> CurrentSubFiles {
        get {
            return _currentSubFiles;
        }
        set {
            _currentSubFiles = value;
            OnPropertyChanged("CurrentSubFiles");
        }
    }
    private FileVM _currentFile;
    public FileVM CurrentFile {
        get {
            return _currentFile;
        }
        set {
            ClosePage();
            _currentFile = value;
            OnPropertyChanged("CurrentFile");
        }
    }
    public FileVM SelectedFile { get; set; }

    public string DbName { get; set; }

    public EntryDataVM EntryData { get; set; }

    private object _currentView;

    public object CurrentView {
        get {
            return _currentView;
        }
        set {
            _currentView = value;
            OnPropertyChanged("CurrentView");
        }
    }

    public DataBaseContextVM () {
        EntryData = new EntryDataVM();
        //CurrentFile = ModelAPI.GetRootFolder();
        CurrentSubFiles = new ObservableCollection<FileVM>();

        FolderVM f1 = new(null);
        FolderVM f2 = new(f1);
        FolderVM f3 = new(f1);
        FolderVM f4 = new(f2);
        FolderVM f5 = new(f2);
        FolderVM f6 = new(f3);
        EntryVM en1 = new(f2);
        EntryVM en2 = new(f4);
        f1.Name = "f1";
        f2.Name = "f2";
        f3.Name = "f3";
        f4.Name = "f4";
        f5.Name = "f5";
        f6.Name = "f6";
        en1.Name = "en1";
        en1.Description = "test entry 1";
        en1.Url = "https://test1";
        en2.Name = "en2";
        en2.Description = "test entry 2";
        en2.Url = "https://test2";

        f1.SubFiles.Add(f2);
        f1.SubFiles.Add(f3);
        f2.SubFiles.Add(f4);
        f2.SubFiles.Add(en1);
        f2.SubFiles.Add(f5);
        f3.SubFiles.Add(f6);
        f4.SubFiles.Add(en2);

        CurrentSubFiles = f1.SubFiles;
        CurrentFile = f1;

        SelectFile = new RelayCommand(Select, CanSelect);
        GoToUpFolder = new RelayCommand(ClimbUp, CanClimbUp);
        NewEntry = new RelayCommand(ShowCreateEntryForm, CanShowCreateEntryForm);
        NewFolder = new RelayCommand(ShowCreateFolderForm, CanShowCreateFolderForm);
        ExitDB = new RelayCommand(Exit, CanExit);
    }

    private bool CanSelect (object obj) {
        return true;
    }

    private void Select (object obj) {
        if (SelectedFile is FolderVM) {
            FolderVM selected = SelectedFile as FolderVM;
            GoIntoTheFolder(selected);
        }
        if (SelectedFile is EntryVM) {
            EntryVM? SelectedEntry = SelectedFile as EntryVM;

            EntryData.Name = SelectedEntry?.Name;
            EntryData.Password = "******";
            EntryData.Description = SelectedEntry?.Description;
            EntryData.URL = SelectedEntry?.Url;
            EntryData.DBContext = this;

            CurrentView = new EntryDataView(EntryData);
        }
    }

    private void GoIntoTheFolder (FolderVM selected) {
        //ModelAPI.GoIntoTheFolder(selected.Name);
        CurrentSubFiles = selected.SubFiles;
        CurrentFile = selected;
    }

    private bool CanClimbUp (object obj) {
        FolderVM? parent = (CurrentFile as FolderVM).Parent;
        return parent != null;
    }

    private void ClimbUp (object obj) {
        //ModelAPI.ClimbUp();
        FolderVM parent = (CurrentFile as FolderVM).Parent;

        CurrentSubFiles = parent.SubFiles;
        CurrentFile = parent;
    }

    private bool CanShowCreateEntryForm (object obj) {
        return true;
    }

    private void ShowCreateEntryForm (object obj) {
        AddEntryView addEntryView = new AddEntryView();
        IUnityContainer container = ControlRegister.RegisterControl(addEntryView);

        AddEntryVM createForm = new AddEntryVM();
        createForm.DBContext = this;
        createForm.Container = container;

        addEntryView.DataContext = createForm;
        CurrentView = addEntryView;
    }
    private bool CanShowCreateFolderForm (object obj) {
        return true;
    }

    private void ShowCreateFolderForm (object obj) {
        AddFolderVM createForm = new AddFolderVM();
        createForm.DBContext = this;
        CurrentView = new AddFolderView(createForm);
    }

    private bool CanExit (object obj) {
        return true;
    }

    private void Exit (object obj) {
        //ModelAPI.Exit();
        Window window = obj as Window;
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        window?.Close();
    }

    public void ClosePage () {
        CurrentView = null;
    }
}
