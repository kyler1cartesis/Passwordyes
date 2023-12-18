using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Xml.Linq;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Password_Manager.MVVM.View.ViewUtilities;
using Unity;

namespace Password_Manager.MVVM.ViewModel
{
    public class DataBaseContextVM : ObservableObject
    {
        private ControlManager _controlManager;
        private MessageBoxManager _dialogManager;
        private DBSettingsVM _dbSettingsView;

        public ICommand SelectFile { get; set; }
        public ICommand GoToUpFolder { get; set; }
        public ICommand NewEntry { get; set; }
        public ICommand NewFolder { get; set; }
        public ICommand ExitDB { get; set; }
        public ICommand DeleteFolderCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand CollapseWindowCommand { get; set; }
        public ICommand OpenSettingsCommand { get; set; }


        private ObservableCollection<FileVM> _currentSubFiles;
        public ObservableCollection<FileVM> CurrentSubFiles
        {
            get
            {
                return _currentSubFiles;
            }
            set
            {
                _currentSubFiles = value;
                OnPropertyChanged(nameof(CurrentSubFiles));
            }
        }
        private FileVM? _currentFile;
        public FileVM? CurrentFile 
        {
            get => _currentFile;
            set
            {
                ClosePage();
                _currentFile = value;
                OnPropertyChanged(nameof(CurrentFile));
            } 
        }

        private FileVM? _selectedFile;
        public FileVM? SelectedFile
        {
            get => _selectedFile;
            set { _selectedFile = value; OnPropertyChanged(nameof(SelectedFile)); }
        }

        public DBDescriptionVM DataBase { get; set; }

        private object? _currentView;

        public object? CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public DataBaseContextVM(DBDescriptionVM dBDescription)
        {
            FolderVM? root = ModelAPI.GetRootFolder();
            if (root != null)
            {
                CurrentFile = root;
                _currentSubFiles = root.SubFiles;
            }
            _controlManager = new ControlManager();
            _dialogManager = new MessageBoxManager();
            _dbSettingsView = new DBSettingsVM();
            DataBase = dBDescription;

            //FolderVM f1 = new(null, "f1");
            //FolderVM f2 = new(f1, "f2");
            //FolderVM f3 = new(f1, "f3");
            //FolderVM f4 = new(f2, "f4");
            //FolderVM f5 = new(f2, "f5");
            //FolderVM f6 = new(f3, "f6");
            //EntryVM en1 = new(f2, "en1");
            //EntryVM en2 = new(f4, "en2");
            //f1.Name = "f1";
            //f2.Name = "f2";
            //f3.Name = "f3";
            //f4.Name = "f4";
            //f5.Name = "f5";
            //f6.Name = "f6";
            //en1.Name = "en1";
            //en1.Description = "test entry 1";
            //en1.Url = "https://test1";
            //en2.Name = "en2";
            //en2.Description = "test entry 2";
            //en2.Url = "https://test2";

            //f1.SubFiles.Add(f2);
            //f1.SubFiles.Add(f3);
            //f2.SubFiles.Add(f4);
            //f2.SubFiles.Add(en1);
            //f2.SubFiles.Add(f5);
            //f3.SubFiles.Add(f6);
            //f4.SubFiles.Add(en2);

            //_currentSubFiles = f1.SubFiles;
            //CurrentFile = f1;

            SelectFile = new RelayCommand(Select, CanSelect);
            GoToUpFolder = new RelayCommand(ClimbUp, CanClimbUp);
            NewEntry = new RelayCommand(ShowCreateEntryForm, CanShowCreateEntryForm);
            NewFolder = new RelayCommand(ShowCreateFolderForm, CanShowCreateFolderForm);
            ExitDB = new RelayCommand(Exit, CanExit);
            DeleteFolderCommand = new RelayCommand(DeleteFolder, CanDeleteFolder);
            CloseWindowCommand = new RelayCommand(CloseWindow);
            CollapseWindowCommand = new RelayCommand(CollapseWindow);
            OpenSettingsCommand = new RelayCommand(OpenSettings);
        }

        private bool CanSelect(object obj)
        {
            return true;
        }

        private void Select(object obj)
        {
            if (SelectedFile is FolderVM)
            {
                SelectFileHandler((FolderVM)SelectedFile);
            }
            if (SelectedFile is EntryVM)
            {
                SelectFileHandler((EntryVM)SelectedFile);
            }
        }

        private void SelectFileHandler(FolderVM folder)
        {
            GoIntoTheFolder(folder);
        }

        private void SelectFileHandler(EntryVM entry)
        {
            EntryDataView entryDataView = _controlManager.CreateControl<EntryDataView>();
            IUnityContainer container = _controlManager.RegisterControl(entryDataView);

            EntryDataVM entryDataVM = CreateEntryDataFormVM(entry.Name, entry.Password, entry.Description, entry.Url, entry.Login, container);

            _controlManager.BindDataContextToControl(entryDataView, entryDataVM);
            CurrentView = entryDataView;
        }

        private EntryDataVM CreateEntryDataFormVM(string Name, byte[] Password, string? Description, string? URL, string? Login, IUnityContainer container)
        {
            return new EntryDataVM(this, Name, Password, Description, URL, Login, container);
        }

        private void GoIntoTheFolder(FolderVM selectedFolder)
        {
            SetFolderContext(selectedFolder);
        }

        private bool CanClimbUp(object obj)
        {
            FolderVM? parent = ((FolderVM?)CurrentFile)?.Parent;
            return parent != null;
        }
        
        private void ClimbUp(object obj)
        {
            FolderVM? parent = ((FolderVM?)CurrentFile)?.Parent;

            if (parent == null) throw new NullReferenceException("Parent was null while climb up");

            SetFolderContext(parent);
        }

        private void SetFolderContext(FolderVM folder)
        {
            CurrentFile = folder;
            CurrentSubFiles = folder.SubFiles;
        }

        private bool CanShowCreateEntryForm(object obj)
        {
            return true;
        }

        private void ShowCreateEntryForm(object obj)
        {
            AddEntryView addEntryView = _controlManager.CreateControl<AddEntryView>();
            IUnityContainer container = _controlManager.RegisterControl(addEntryView);

            AddEntryFormVM entryForm = CreateAddEntryFormVM(container);

            _controlManager.BindDataContextToControl(addEntryView, entryForm);

            CurrentView = addEntryView;
        }

        private AddEntryFormVM CreateAddEntryFormVM(IUnityContainer container)
        {
            return new AddEntryFormVM(this, container);
        }

        private bool CanShowCreateFolderForm(object obj)
        {
            return true;
        }

        private void ShowCreateFolderForm(object obj)
        {
            AddFolderView addFolderForm = _controlManager.CreateControl<AddFolderView>();

            AddFolderFormVM addFolderVM = CreateAddFolderFormVM();

            _controlManager.BindDataContextToControl(addFolderForm, addFolderVM);
            
            CurrentView = addFolderForm;
        }

        private AddFolderFormVM CreateAddFolderFormVM()
        {
            return new AddFolderFormVM(this);
        }

        private bool CanExit(object obj)
        {
            return true;
        }

        private void Exit(object obj)
        {
            ModelAPI.Exit();
            Window dbContextWin = (Window)obj;
            MainWindow mainWindow = _controlManager.CreateWindow<MainWindow>();

            _controlManager.ShowWindowAtCenter(mainWindow);
            _controlManager.CloseWindow(dbContextWin);
        }

        public void ClosePage()
        {
            CurrentView = null;
        }

        private bool CanDeleteFolder(object obj)
        {
            return SelectedFile is FolderVM;
        }

        private void DeleteFolder(object obj)
        {
            FolderVM? folderToDelete = (FolderVM?)SelectedFile;
            FolderVM? currentFolder = (FolderVM?)CurrentFile;

            if (folderToDelete == null) throw new NullReferenceException("folderToDelete was null while delete folder");
            if (currentFolder == null) throw new NullReferenceException("CurrentFile was null while delete folder");

            var answer = _dialogManager.ShowMessageBox("Вы уверены, что хотите удалить запись: " + folderToDelete.Name + " ?",
                                                        "удаление БД",
                                                        MessageBoxImage.Question);

            if (answer == MessageBoxResult.No) return;

            currentFolder.RemoveFileByName<FolderVM>(folderToDelete.Name);

            ClosePage();
        }

        private void CloseWindow(object obj)
        {
            Window window = (Window)obj;
            window.Close();
        }

        private void CollapseWindow(object obj)
        {
            Window window = (Window)obj;
            window.WindowState = WindowState.Minimized;
        }

        private void OpenSettings(object obj)
        {
            _dbSettingsView.Message = string.Empty;
            CurrentView = _dbSettingsView;
        }
    }
}
