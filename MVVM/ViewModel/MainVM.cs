using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;

namespace Password_Manager.MVVM.ViewModel
{
    public class MainVM : ObservableObject
    {
        private ControlManager _controlManager;
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand DataBasesViewCommand { get; set; }

        public RelayCommand SettingsViewCommand { get; set; }


        public HomeVM HomeVM { get; set; }

        public DataBasesVM DataBasesVM { get; set; }

        public SettingsVM SettingsVM { get; set; }


        private object? _currentView;

        public object? CurrentView
        {
            get => _currentView;
            set 
            { 
                _currentView = value; 
                OnPropertyChanged(nameof(CurrentView)); 
            }
        }


        public MainVM()
        {
            _controlManager = new ControlManager();
            HomeVM = new HomeVM();
            DataBasesVM = new DataBasesVM();
            DataBasesVM.MainVM = this;

            SettingsVM = new SettingsVM();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(obj => 
            {
                CurrentView = HomeVM;

            });

            DataBasesViewCommand = new RelayCommand(obj =>
            {
                DataBasesView dbView = _controlManager.CreateControl<DataBasesView>();
                _controlManager.BindDataContextToControl(dbView, DataBasesVM);
                CurrentView = dbView;
            });

            SettingsViewCommand = new RelayCommand(obj =>
            {
                CurrentView = SettingsVM;
            });
        }
    }
}
