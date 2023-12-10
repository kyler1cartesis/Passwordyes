using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Password_Manager.MVVM.View.ViewUtilities;
using Unity;

namespace Password_Manager.MVVM.ViewModel
{
    class SignInDBFormVM : ObservableObject
    {
		private MainVM _mainVM;
		private MessageBoxManager _dialogManager;
		private ControlManager _controlManager;
		private IUnityContainer _container;
		public ICommand SignInDataBaseCommand { get; set; }
        public ICommand CloseFormCommand { get; set; }

        public DBDescriptionVM DbToSignIn { get; set; }

		public string MasterPassword
		{
			get
			{
				IPasswordSupplier passwordSupplier = _container.Resolve<IPasswordSupplier>();
				return passwordSupplier.GetPassword();
			}
		}

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

		public string FormName
		{
			get => "Вход в \"" + DbToSignIn.Name + "\"";
		}

        public SignInDBFormVM(DBDescriptionVM dbToSignIn, MainVM mainVM, IUnityContainer contianer)
		{
			DbToSignIn = dbToSignIn;
			_dialogManager = new MessageBoxManager();
			_mainVM = mainVM;
			_container = contianer;
			_errorMessage = string.Empty;
			_controlManager = new ControlManager();

			SignInDataBaseCommand = new RelayCommand(Enter, CanEnter);
            CloseFormCommand = new RelayCommand(Close);
        }

		private bool CanEnter(object obj)
		{
            return DbToSignIn != null;
		}

		private void Enter(object obj)
		{
			bool isValidate = ModelAPI.VerifyPassword(DbToSignIn, MasterPassword);

			if (isValidate)
			{
				//ModelAPI.SignInBD(DbToSignIn);

                MainWindow mainWindow = (MainWindow)obj;

                DataBaseContextWindow dbContextWin = _controlManager.CreateWindow<DataBaseContextWindow>();

                DataBaseContextVM dbContextVM = CreateDBContextVM();

				_controlManager.BindDataContextToWindow(dbContextWin, dbContextVM);

				_controlManager.ShowWindowAtCenter(dbContextWin);
				_controlManager.CloseWindow(mainWindow);
			}
			else
			{
                var answer = _dialogManager.ShowMessageBox("Парль не подходит!",
                                                        "Попытка входа",
                                                        MessageBoxImage.Error);
            }
		}

		private DataBaseContextVM CreateDBContextVM()
		{
			return new DataBaseContextVM(DbToSignIn);
        }

        private void Close(object obj)
        {
            _mainVM.DataBasesViewCommand.Execute(null);
        }
    }
}
