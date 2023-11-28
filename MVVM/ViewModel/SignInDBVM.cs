using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;

namespace Password_Manager.MVVM.ViewModel
{
    class SignInDBVM : ObservableObject
    {
		private MainViewModel _mainVM;
		//Команда добавления БД в коллекцию
		public ICommand SignInDataBaseCommand { get; set; }

		//Поле с именем новой БД
		public DBDescriptionVM DbToSignIn { get; set; }

		public string MasterPassword { get; set; }


		public SignInDBVM()
		{
			SignInDataBaseCommand = new RelayCommand(Enter, CanEnter);
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

                var signInDataBaseContextWindow = obj as Window;

				DataBaseContextVM dbContextVM = new DataBaseContextVM();
				dbContextVM.DbName = DbToSignIn.Name;
				DataBaseContextWindow dbContextWin = new DataBaseContextWindow();
				dbContextWin.DataContext = dbContextVM;

				dbContextWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				dbContextWin.Show();
				signInDataBaseContextWindow.Owner.Close();
			}
			else
			{

			}
		}
	}
}
