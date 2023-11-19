using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;

namespace Password_Manager.MVVM.ViewModel
{
    public class DataBaseContextVM : ObservableObject
    {
        private DbContext _context;

        public string CurrentFolderName
        {
            get
            {
                return CurrentFolder.Name;
            }
        }

        public ICommand SelectFile { get; set; }
        public ICommand GoToUpFolder { get; set; }
        public ObservableCollection<File> CurrentSubFiles { get; set; } = new ObservableCollection<File>();
        public File CurrentFolder { get; set; }
        public File SelectedFolder { get; set; }

        public DbContext Context { get { return _context; } }

        public string DbName { get; set; }

        public CreateEntryVM CreateEntryForm  { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public DataBaseContextVM()
        {
            CreateEntryForm = new CreateEntryVM();

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

            foreach (FolderVM f in f1.SubFiles)
            {
                CurrentSubFiles.Add(f);
            }
            CurrentFolder = f1;

            DbContext context = new DbContext();
            _context = context;

            SelectFile = new RelayCommand(Select, CanSelect);
            GoToUpFolder = new RelayCommand(ClimbUp, CanClimbUp);
        }

        private bool CanSelect(object obj)
        {
            return true;
        }

        private void Select(object obj)
        {
            if(SelectedFolder is FolderVM)
            {
                FolderVM selected = SelectedFolder as FolderVM;
                ShowSubFiles(selected);
            }
            if(SelectedFolder is EntryVM)
            {
                EntryVM? SelectedEntry = SelectedFolder as EntryVM;
                Debug.WriteLine(CreateEntryForm.Name);


                CreateEntryForm.Name = SelectedEntry?.Name;
                CreateEntryForm.Name = SelectedEntry?.Name;
                CreateEntryForm.Password = "******";
                CreateEntryForm.Description = SelectedEntry?.Description;
                CreateEntryForm.URL = SelectedEntry?.Url;
                CurrentView = new CreateEntryForm(CreateEntryForm);
            }
        }

        private void ShowSubFiles(FolderVM selected)
        {
            CurrentSubFiles.Clear();
            foreach (File f in selected.SubFiles)
            {
                CurrentSubFiles.Add(f);
            }
            CurrentFolder = selected;
        }

        private bool CanClimbUp(object obj)
        {
            FolderVM? parent = (CurrentFolder as FolderVM).Parent;
            return parent != null;
        }

        private void ClimbUp(object obj)
        {
            CurrentSubFiles.Clear();
            FolderVM parent = (CurrentFolder as FolderVM).Parent;

            foreach (File f in parent.SubFiles)
            {
                CurrentSubFiles.Add(f);
            }
            CurrentFolder = parent;
        }
    }
}
