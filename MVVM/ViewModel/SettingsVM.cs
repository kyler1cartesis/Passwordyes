using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel
{
    public class SettingsVM : ObservableObject
    {
        private AppSettings _settings;

        public ICommand ConfirmCommand { get; set; }
        public ICommand RunFileManagerCommand { get; set; }

        private int _time;
        public int Time
        {
            get => _time; 
            set { _time = value; OnPropertyChanged(nameof(Time)); }
        }

        private string _workDirectory;
        public string WorkDirectory
        {
            get => _workDirectory;
            set { _workDirectory = value; OnPropertyChanged(nameof(WorkDirectory)); }
        }

        public SettingsVM()
        {

            if (ConfigUtil.AppConf.Sections["StormSettings"] == null)
            {
                ConfigUtil.AppConf.Sections.Add("StormSettings", new AppSettings());
            }

            _settings = (AppSettings)ConfigUtil.AppConf.GetSection("StormSettings");

            _time = _settings.TimeToDelete;
            _workDirectory = _settings.WorkDir;

            ConfirmCommand = new RelayCommand(SaveSettings);
            RunFileManagerCommand = new RelayCommand(RunFileManager);
        }

        private void SaveSettings(object ibj)
        {
            _settings.WorkDir = _workDirectory;
            _settings.TimeToDelete = _time;

            ConfigUtil.AppConf.Save();
        }

        private void RunFileManager(object obj)
        {
            Microsoft.Win32.OpenFolderDialog dialog = new();

            dialog.Multiselect = false;
            dialog.Title = "Select a folder";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                WorkDirectory = dialog.FolderName;
            }
        }
    }
}
