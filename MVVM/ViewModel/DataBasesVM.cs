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
    public class DataBasesVM : ObservableObject
    {
        private MessageBoxManager _dialogManager;
        private ControlManager _controlManager;

        public ICommand ShowAddDbWindowCommand { get; set; }
        public ICommand ShowSignInDbWindowCommand { get; set; }
        public ICommand DeleteDBCommand { get; set; }

        private ObservableCollection<DBDescriptionVM> _dBDescriptions;
        public ObservableCollection<DBDescriptionVM> DBDescriptions 
        {
            get => _dBDescriptions;
            set 
            {
                _dBDescriptions = value;
                OnPropertyChanged(nameof(DBDescriptions));
            }
        }

        private MainVM? _mainVM;
        public MainVM MainVM { set => _mainVM = value; }

        private DBDescriptionVM? _selectedBD;
        public DBDescriptionVM? SelectedDB
        {
            get => _selectedBD;
            set
            {
                _selectedBD = value;
                OnPropertyChanged("SelectedDB");
            }
        }

        public DataBasesVM()
        {
            _dBDescriptions = new ObservableCollection<DBDescriptionVM>();
            DBDescriptions = new ObservableCollection<DBDescriptionVM>();
            _dialogManager = new MessageBoxManager();
            _controlManager = new ControlManager();

            ShowAddDbWindowCommand = new RelayCommand(CreateShowAddDBForm, CanShowAddDBWindow);
            ShowSignInDbWindowCommand = new RelayCommand(CreateAndShowSignInDBForm, CanShowSignInDBWindow);
            DeleteDBCommand = new RelayCommand(DeleteDB, CanDeleteDB);

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
            var answer = _dialogManager.ShowMessageBox("Вы уверены, что хотите удалить базу данных: " + SelectedDB?.Name + " ?\n БД будет удалена без возможности восстановления!", 
                                                        "удаление БД", 
                                                        MessageBoxImage.Question);
            
            if (answer == MessageBoxResult.Yes)
                DeleteDBD(SelectedDB);
        }

        private void CreateShowAddDBForm(object obj)
        {
            AddDBView addDBView = _controlManager.CreateControl<AddDBView>();
            var container = _controlManager.RegisterControl(addDBView);
            AddDBFormVM addDBVM = CreateAddDBVM(container);

            _controlManager.BindDataContextToControl(addDBView, addDBVM);
            SetMainVMCurrentView(addDBView);
        }

        private AddDBFormVM CreateAddDBVM(IUnityContainer container)
        {
            if (_mainVM == null) throw new ArgumentException("MainVM was null while AddDBVM created");

            return new AddDBFormVM(_mainVM, container);
        }
        private void CreateAndShowSignInDBForm(object obj)
        {
            SignInDBView signInDBView = _controlManager.CreateControl<SignInDBView>();
            var container = _controlManager.RegisterControl(signInDBView);
            SignInDBFormVM signInDBVM = CreateSignInDBVM(container);

            _controlManager.BindDataContextToControl(signInDBView, signInDBVM);
            SetMainVMCurrentView(signInDBView);
        }

        private SignInDBFormVM CreateSignInDBVM(IUnityContainer container)
        {
            if (_mainVM == null) throw new ArgumentException("MainVM was null while SignInDBVM created");
            if (SelectedDB == null) throw new ArgumentException("SelectedDB was null while SignInDBVM created");

            return new SignInDBFormVM(SelectedDB, _mainVM, container);
        }
        private void SetMainVMCurrentView(UserControl view)
        {
            if (_mainVM == null) throw new ArgumentException("MainVM was null while set currentView");

            _mainVM.CurrentView = view;
        }

        public void AddDBD(DBDescriptionVM dBDescription, string Password)
        {
            ModelAPI.CreateNewDB(dBDescription, Password);
            UpdateDBDs();
            
            //DBDescriptions.Add(dBDescription);
        }

        private void DeleteDBD(DBDescriptionVM? dBDescription)
        {
            if (dBDescription == null) throw new NullReferenceException("dBDescription was null while delete db");

            ModelAPI.RemoveDB(dBDescription);
            UpdateDBDs();

            //DBDescriptions.Remove(dBDescription);
        }

        private void UpdateDBDs()
        {

            DBDescriptions = ModelAPI.GetDBDescriptions();
            /*DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №1",
               
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });

            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.HIGH
            });

            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.MID
            });
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.HIGH
            });
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
            DBDescriptions.Add(new DBDescriptionVM
            {
                Name = "Test DataBase №2",
                
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });*/
        }
    }
}
