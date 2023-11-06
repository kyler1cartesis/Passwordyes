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
		//Команда добавления БД в коллекцию
		public ICommand SignInDataBaseCommand { get; set; }

		//Поле с именем новой БД
		public DBDescription DbToSignIn { get; set; }

		public string MasterPassword { get; set; }


		public SignInDBVM()
		{
			SignInDataBaseCommand = new RelayCommand(Enter, CanEnter);
		}

		private bool CanEnter(object obj)
		{
			return true;
		}

		private void Enter(object obj)
		{

			var dataBaseContextWindow = obj as Window;
			DataBaseContextWindow dbContextBWin = new DataBaseContextWindow();
			dbContextBWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			dbContextBWin.DataContext = DbToSignIn;
			dbContextBWin.Show();
			dataBaseContextWindow.Owner.Close();
		}
	}
}
