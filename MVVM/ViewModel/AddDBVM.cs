using System;
using System.Collections.Generic;
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

namespace Password_Manager.MVVM.ViewModel;

public class AddDBVM : ObservableObject
{
	//Команда добавления БД в коллекцию
	public ICommand AddDBCommand { get; set; }
    public ICommand CloseFormCommand { get; set; }
    public ICommand SetCodeLevelCommand { get; set; }

	//Поле с именем новой БД
	public string Name { get; set; }

	//Поле с Мастер паролем новой БД
	public string MasterPassword { get; set; }
	public CodeLevel Level { get; set; }


	public AddDBVM()
	{
		AddDBCommand = new RelayCommand(AddDB, CanAddDB);
		SetCodeLevelCommand = new RelayCommand(SetCodeLevel);
		CloseFormCommand = new RelayCommand(Close);
	}

	private bool CanAddDB(object obj)
	{
		//bool isValidateName = ModelAPI.Validate_DB_Name(Name);
		//bool isValidatePassword = ModelAPI.Validate_DB_MPassword(MasterPassword);
		return true;
	}

	private void AddDB(object obj)
	{
        //ModelAPI.CreateNewDB(Name, MasterPassword);
        var mainWindow = obj as Window;
        MainViewModel mainVM = mainWindow.DataContext as MainViewModel;
        mainVM.DataBasesViewCommand.Execute(null);
		mainVM.DataBasesVM.AddDBD(new DBDescriptionVM(Name, DateTime.Now, Level));
    }

    private void Close(object obj)
    {
        var mainWindow = obj as Window;
        MainViewModel mainVM = mainWindow.DataContext as MainViewModel;
        mainVM.DataBasesViewCommand.Execute(null);
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
