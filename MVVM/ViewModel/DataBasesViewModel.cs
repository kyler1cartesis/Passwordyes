using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using Password_Manager.Core;
using Password_Manager.MVVM.View;

namespace Password_Manager.MVVM.ViewModel
{
    public class DataBasesViewModel : ObservableObject
    {
        ObservableCollection<DBDescriptionVM> _dBDescriptions;
        //Коллекция БД
        public ObservableCollection<DBDescriptionVM> DBDescriptions 
        { 
            get 
            {
                return _dBDescriptions;
            } 
            set 
            {
                _dBDescriptions = value;
                OnPropertyChanged("DBDescriptions");
            }
        }

        //Выбранная БД на данный момент времени
        private DBDescriptionVM _selectedBD;
        public DBDescriptionVM SelectedDB
        {
            get
            {
                return _selectedBD;
            }
            set
            {
                _selectedBD = value;
                OnPropertyChanged("SelectedDB");
            }
        }
        //Команда отображения формы ввода данных новой БД
        public ICommand ShowAddDbWindowCommand { get; set; }
        public ICommand ShowSignInDbWindowCommand { get; set; }
        public ICommand DeleteDBCommand { get; set; }

        private bool CanShowAddDBWindow(object obj)
        {
            return true;
        }

        private bool CanShowSignInDBWindow(object obj)
        {
            return SelectedDB != null;
        }

        private bool CanDeleteDB(object obj)
        {
            return SelectedDB != null;
        }

        private void DeleteDB(object obj)
        {
            //ModelAPI.RemoveDB(SelectedDBD);
            //UpdateDBDs();
            DBDescriptions.Remove(SelectedDB);
        }

        private void ShowAddDBWindow(object obj)
        {
            var mainWindow = obj as Window;
            AddDBVM addDBVM = new AddDBVM();
            AddDBView addDBView = new AddDBView(addDBVM);
            MainViewModel mainVM = mainWindow.DataContext as MainViewModel;
            mainVM.CurrentView = addDBView;
            //addDBWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //addDBWin.Show();
        }

        private void ShowSignInDBWindow(object obj)
        {
            var mainWindow = obj as Window;
            SignInDBVM signInDBVM = new SignInDBVM();
            signInDBVM.DbToSignIn = SelectedDB;
            SignInDataBaseWindow signInDBWindow = new SignInDataBaseWindow(mainWindow);
            signInDBWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            signInDBWindow.DataContext = signInDBVM;
            signInDBWindow.Show();
        }

        //Добавление новой БД в список
        public void AddDBD(DBDescriptionVM dBDescription)
        {
            //ModelAPI.AddNewDB(dBDescription);
            //UpdateDBDs();
            var dbdescs = DBDescriptions;
            dbdescs.Add(dBDescription);
            DBDescriptions = dbdescs;
        }

        private void UpdateDBDs()
        {

            //DBDescriptions = ModelAPI.GetDBDescriptions();
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №1",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });

            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.HIGH
            });

            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.MID
            });
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.HIGH
            });
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
        }

        public DataBasesViewModel()
        {
            ShowAddDbWindowCommand = new RelayCommand(ShowAddDBWindow, CanShowAddDBWindow);

            ShowSignInDbWindowCommand = new RelayCommand(ShowSignInDBWindow, CanShowSignInDBWindow);

            DeleteDBCommand = new RelayCommand(DeleteDB, CanDeleteDB);

            DBDescriptions = new ObservableCollection<DBDescriptionVM>();

            UpdateDBDs();
        }
    }
}
