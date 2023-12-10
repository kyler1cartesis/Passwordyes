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

public class AddDBFormVM : ObservableObject
{
    private MainVM _mainVM;
    private IUnityContainer _container;
    private MessageBoxManager _dialogManager;
    public ICommand AddDBCommand { get; set; }
    public ICommand CloseFormCommand { get; set; }
    public ICommand SetCodeLevelCommand { get; set; }
    public ICommand RunFileManagerCommand {  get; set; }

    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
    }
    private string _name;
	public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); } 
    }
	public string MasterPassword
    {
        get
        {
            IPasswordSupplier passwordSupplier = _container.Resolve<IPasswordSupplier>();
            return passwordSupplier.GetPassword();
        }
    }
    public string MasterPasswordConfirm
    {
        get
        {
            IPasswordSupplier passwordSupplier = _container.Resolve<IPasswordSupplier>();
            return passwordSupplier.GetPasswordConfirm();
        }
    }
    public CodeLevel Level { get; set; }

    private string _hint;
    public string Hint
    {
        get => _hint;
        set { _hint = value; OnPropertyChanged(nameof(Hint)); }
    }

    private string _path;
    public string Path
    {
        get => _path;
        set { _path = value; OnPropertyChanged(nameof(Path)); }
    }

    public AddDBFormVM(MainVM maiNVM, IUnityContainer container)
    {
        _errorMessage = string.Empty;
        _name = string.Empty;
        _mainVM = maiNVM;
        _container = container;
        _dialogManager = new MessageBoxManager();

        AddDBCommand = new RelayCommand(AddDB);
        SetCodeLevelCommand = new RelayCommand(SetCodeLevel);
        CloseFormCommand = new RelayCommand(Close);
        RunFileManagerCommand = new RelayCommand(RunFileManager);
    }

	private void AddDB(object obj)
	{
        //bool isValidatePassword = ModelAPI.Validate_DB_MPassword(MasterPassword, MasterPasswordConfirm);
        //ModelAPI.CreateNewDB(Name, MasterPassword);

        _mainVM.DataBasesViewCommand.Execute(new object());
		_mainVM.DataBasesVM.AddDBD(new DBDescriptionVM(Name, DateTime.Now, Hint, Path), MasterPassword);
    }

    private void Close(object obj)
    {
        var answer = _dialogManager.ShowMessageBox("Отменить создание базы данных?",
                                             "отмена создания БД",
                                             MessageBoxImage.Question);
        
        if (answer == MessageBoxResult.Yes)
            _mainVM.DataBasesViewCommand.Execute(new object());
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
                    throw new Exception("Wrong radio button name");
            }
        }
	}

    private void RunFileManager(object obj)
    {
        Microsoft.Win32.OpenFolderDialog dialog = new();

        dialog.Multiselect = false;
        dialog.Title = "Select a folder";

        bool? result = dialog.ShowDialog();

        if (result == true)
        {
            Path = dialog.FolderName;
        }
    }
}
