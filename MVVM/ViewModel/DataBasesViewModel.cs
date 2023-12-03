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
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Password_Manager.MVVM.View.ViewUtilities;
using Unity;

namespace Password_Manager.MVVM.ViewModel
{
    public class DataBasesViewModel : ObservableObject
    {
        ObservableCollection<DBDescriptionVM> _dBDescriptions;
       
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

        private MainViewModel _mainVM;
        public MainViewModel MainVM { set => _mainVM = value; }

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
        
        public ICommand ShowAddDbWindowCommand { get; set; }
        public ICommand ShowSignInDbWindowCommand { get; set; }
        public ICommand DeleteDBCommand { get; set; }

        public DataBasesViewModel()
        {
            ShowAddDbWindowCommand = new RelayCommand(ShowAddDBForm, CanShowAddDBWindow);

            ShowSignInDbWindowCommand = new RelayCommand(ShowSignInDBForm, CanShowSignInDBWindow);

            DeleteDBCommand = new RelayCommand(DeleteDB, CanDeleteDB);

            DBDescriptions = new ObservableCollection<DBDescriptionVM>();

            UpdateDBDs();
        }

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
            var answer = MessageBoxManager.ShowMessageBox("Вы уверены, что хотите удалить базу данных: " + SelectedDB.Name + " ?\n БД будет удалена без возможности восстановления!", 
                                             "удаление БД", 
                                             MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
                DBDescriptions.Remove(SelectedDB);
            else
                return;
        }

        private void ShowAddDBForm(object obj)
        {
            AddDBView addDBView = new AddDBView();
            var container = ControlRegister.RegisterControl(addDBView);
            AddDBVM addDBVM = new AddDBVM(_mainVM, container);

            addDBView.DataContext = addDBVM;
            _mainVM.CurrentView = addDBView;
        }

        private void ShowSignInDBForm(object obj)
        {
            SignInDBView signInDBView = new SignInDBView();
            var container = ControlRegister.RegisterControl(signInDBView);
            SignInDBVM signInDBVM = new SignInDBVM(SelectedDB, _mainVM, container);

            signInDBView.DataContext = signInDBVM;
            _mainVM.CurrentView = signInDBView;
        }

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
    }
}
