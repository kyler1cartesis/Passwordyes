using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Password_Manager.MVVM.View.ViewUtilities;
using Unity;

namespace Password_Manager.MVVM.ViewModel
{
    class SignInDBVM : ObservableObject
    {
		private MainViewModel _mainVM;
		private IUnityContainer _container;
		//Команда добавления БД в коллекцию
		public ICommand SignInDataBaseCommand { get; set; }
        public ICommand CloseFormCommand { get; set; }

        //Поле с именем новой БД
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

        public SignInDBVM(DBDescriptionVM dbToSignIn, MainViewModel mainVM, IUnityContainer contianer)
		{
			DbToSignIn = dbToSignIn;
			_mainVM = mainVM;
			_container = contianer;

			SignInDataBaseCommand = new RelayCommand(Enter, CanEnter);
            CloseFormCommand = new RelayCommand(Close);
        }

		private bool CanEnter(object obj)
		{
            return DbToSignIn != null;
		}

		private void Enter(object obj)
		{
			//bool isValidate = ModelAPI.VerifyPassword(DbToSignIn, MasterPassword);

			if (true)
			{
				//ModelAPI.SignInBD(DbToSignIn);

                var mainWindow = obj as Window;

				DataBaseContextVM dbContextVM = new DataBaseContextVM(DbToSignIn);
				
				DataBaseContextWindow dbContextWin = new DataBaseContextWindow();
				dbContextWin.DataContext = dbContextVM;

				dbContextWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				dbContextWin.Show();
				mainWindow.Close();
			}
			else
			{

			}
		}

        private void Close(object obj)
        {
            _mainVM.DataBasesViewCommand.Execute(null);
        }
    }
}
