using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel;

class AddDBVM : ObservableObject
{
	//Команда добавления БД в коллекцию
	public ICommand AddDBCommand { get; set; }
	public ICommand SetCodeLevelCommand { get; set; }

	//Поле с именем новой БД
	public string Name { get; set; }

	//Поле с Мастер паролем новой БД
	public string MasterPassword { get; set; }
	public CodeLevel Level { get; set; }


	public AddDBVM()
	{
		AddDBCommand = new RelayCommand(AddUser, CanAddUser);
		SetCodeLevelCommand = new RelayCommand(SetCodeLevel);
	}

	private bool CanAddUser(object obj)
	{
		//bool isValidateName = ModelAPI.Validate_DB_Name(Name);
		//bool isValidatePassword = ModelAPI.Validate_DB_MPassword(MasterPassword);
		return true;
	}

	private void AddUser(object obj)
	{
		//ModelAPI.CreateNewDB(Name, MasterPassword);
		DataBasesViewModel.AddDBD(new Model.DBDescription(Name, DateTime.Now, Level)); ;

	}

	private void SetCodeLevel(object obj)
	{
		RadioButton? button = obj as RadioButton;
        if (button != null)
		{
            switch (button.Name)
            {
                case "low":
                    Level = CodeLevel.LOW;
					break;
                case "mid":
                    Level = CodeLevel.MID;
                    break;
                case "high":
                    Level = CodeLevel.HIGH;
                    break;
                default:
                    throw new Exception("Wrong radion button name");
            }
        }
	}
}
