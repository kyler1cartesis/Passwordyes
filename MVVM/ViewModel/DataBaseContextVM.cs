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

namespace Password_Manager.MVVM.ViewModel
{
    class DataBaseContextVM : ObservableObject
    {
        private DbContext _context;

        public string CurrentFolderName
        {
            get
            {
                return CurrentFolder.Name;
            }
        }

        public ICommand SelectFolder { get; set; }
        public ICommand GoToUpFolder { get; set; }
        public ObservableCollection<File> CurrentSubFiles { get; set; } = new ObservableCollection<File>();
        public File CurrentFolder { get; set; }
        public File SelectedFolder { get; set; }

        public DbContext Context { get { return _context; } }

        public string DbName { get; set; }

        public DataBaseContextVM()
        {
            FolderVM f1 = new(null);
            FolderVM f2 = new(f1);
            FolderVM f3 = new(f1);
            FolderVM f4 = new(f2);
            FolderVM f5 = new(f2);
            FolderVM f6 = new(f3);
            f1.Name = "f1";
            f2.Name = "f2";
            f3.Name = "f3";
            f4.Name = "f4";
            f5.Name = "f5";
            f6.Name = "f6";

            f1.SubFiles.Add(f2);
            f1.SubFiles.Add(f3);
            f2.SubFiles.Add(f4);
            f2.SubFiles.Add(f5);
            f3.SubFiles.Add(f6);

            foreach (FolderVM f in f1.SubFiles)
            {
                CurrentSubFiles.Add(f);
            }
            CurrentFolder = f1;

            DbContext context = new DbContext();
            _context = context;

            SelectFolder = new RelayCommand(ShowSubEntries, CanShowSubEntries);
            GoToUpFolder = new RelayCommand(ClimbUp, CanClimbUp);
        }

        private bool CanShowSubEntries(object obj)
        {
            return true;
        }

        private void ShowSubEntries(object obj)
        {
            FolderVM selected = SelectedFolder as FolderVM;
            CurrentSubFiles.Clear();
            foreach(FolderVM f in selected.SubFiles)
            {
                CurrentSubFiles.Add(f);
            }
            CurrentFolder = selected;
            Debug.WriteLine(selected.SubFiles.Count);
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

            Debug.WriteLine("Try to get subfiles " + parent.SubFiles.Count);
            foreach (FolderVM f in parent.SubFiles)
            {
                CurrentSubFiles.Add(f);
                Debug.WriteLine(f.Name);
            }
            CurrentFolder = parent;
        }
    }
}
