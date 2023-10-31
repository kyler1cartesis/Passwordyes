﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel
{
    public class AddDBVM
    {
		//Команда добавления БД в коллекцию
		public ICommand AddDBCommand { get; set; }

		//Поле с именем новой БД
		public string Name { get; set; }

		//Поле с Мастер паролем новой БД
		public DateTime CreateData { get; set; }


		public AddDBVM()
		{
			AddDBCommand = new RelayCommand(AddUser, CanAddUser);
		}

		private bool CanAddUser(object obj)
		{
			return true;
		}

		private void AddUser(object obj)
		{

			DataBasesViewModel.AddDBD(new Model.DBDescription(Name, CreateData)); ;

		}
	}
}