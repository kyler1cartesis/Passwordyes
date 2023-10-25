using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DataBasesViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public DataBasesViewModel DataBasesVM { get; set; }

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
                OnPropertyChanged(); 
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DataBasesVM = new DataBasesViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(obj => 
            {
                CurrentView = HomeVM;

            });

            DataBasesViewCommand = new RelayCommand(obj =>
            {
                CurrentView = DataBasesVM;

            });
        }
    }
}
