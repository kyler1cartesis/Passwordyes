using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;
using Password_Manager.MVVM.View.ViewUtilities;
using Unity;

namespace Password_Manager.MVVM.ViewModel;

public class AddDBVM : ObservableObject
{
    private MainViewModel _mainVM;
	//Команда добавления БД в коллекцию
	public ICommand AddDBCommand { get; set; }
    public ICommand CloseFormCommand { get; set; }
    public ICommand SetCodeLevelCommand { get; set; }

    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
    }
	//Поле с именем новой БД
    private string _name;
	public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); } 
    }

    //Поле с Мастер паролем новой БД
    private IUnityContainer _container;
	public Tuple<string, string> MasterPassword
    {
        get
        {
            IPasswordSupplier passwordSupplier = _container.Resolve<IPasswordSupplier>();
            return passwordSupplier.GetPassword();
        }
    }
	public CodeLevel Level { get; set; }


	public AddDBVM(MainViewModel maiNVM, IUnityContainer container)
	{
        _mainVM = maiNVM;
        _container = container;
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
        _mainVM.DataBasesViewCommand.Execute(null);
		_mainVM.DataBasesVM.AddDBD(new DBDescriptionVM(Name, DateTime.Now, Level));
    }

    private void Close(object obj)
    {
        _mainVM.DataBasesViewCommand.Execute(null);
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
