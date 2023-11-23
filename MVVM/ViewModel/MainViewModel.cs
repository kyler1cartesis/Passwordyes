using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.Core;
using Password_Manager.MVVM.View;

namespace Password_Manager.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        //Команда смены страницы на главную
        public RelayCommand HomeViewCommand { get; set; }

        //Команда смены страницы на список БД
        public RelayCommand DataBasesViewCommand { get; set; }

        //Команда смены страницы на настройки
        public RelayCommand SettingsViewCommand { get; set; }


        //ViewModel главной страницы 
        public HomeViewModel HomeVM { get; set; }

        //ViewModel страницы списка БД
        public DataBasesViewModel DataBasesVM { get; set; }

        //ViewModel страницы настроек
        public SettingsViewModel SettingsVM { get; set; }


        //Поле хранения текущей страницы
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


        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DataBasesVM = new DataBasesViewModel();
            SettingsVM = new SettingsViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(obj => 
            {
                CurrentView = HomeVM;

            });

            DataBasesViewCommand = new RelayCommand(obj =>
            {
                //CurrentView = DataBasesVM;
                var dbView = new DataBasesView();
                CurrentView = dbView;
                dbView.DataContext = DataBasesVM;
            });

            SettingsViewCommand = new RelayCommand(obj =>
            {
                CurrentView = SettingsVM;

            });
        }
    }
}
