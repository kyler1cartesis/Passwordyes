﻿using System;
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
    public ICommand RunFileManagerCommand { get; set; }
    public ICommand ShowPwdCommand { get; set; }

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
    private bool _isHide = true;
    public bool IsShown
    {
        get => _isHide;
        set { _isHide = value; OnPropertyChanged(nameof(IsShown)); }
    }

    public string _passwordToShow = string.Empty;
    public string PasswordToShow
    {
        get => _passwordToShow;
        set
        {
            _passwordToShow = value; OnPropertyChanged(nameof(PasswordToShow));
        }
    }
    public string MasterPassword
    {
        set
        {
            IPasswordSupplier supl = _container.Resolve<IPasswordSupplier>();
            supl.SetPassword(value);
        }
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
        var settings = (AppSettings)ConfigUtil.AppConf.GetSection("StormSettings");

        _errorMessage = string.Empty;
        _name = string.Empty;
        _mainVM = maiNVM;
        _container = container;
        _dialogManager = new MessageBoxManager();
        _hint = string.Empty;
        _path = settings.WorkDir;

        AddDBCommand = new RelayCommand(AddDB);
        SetCodeLevelCommand = new RelayCommand(SetCodeLevel);
        CloseFormCommand = new RelayCommand(Close);
        RunFileManagerCommand = new RelayCommand(RunFileManager);
        ShowPwdCommand = new RelayCommand(SwitchPasswordVisibility);
    }

	private void AddDB(object obj)
	{
        if (IsShown)
        {
            MasterPassword = PasswordToShow;
            PasswordToShow = string.Empty;
        }

        bool isPasswordCorrect = ModelAPI.CheckPassword(MasterPassword);
        if (!isPasswordCorrect)
        {
            _dialogManager.ShowMessageBox("Пароль пустой или содержит слишком много символов!",
                                             "ошибка данных",
                                             MessageBoxImage.Error);
            return;
        }


        bool isValidatePassword = ModelAPI.ValidatePassword(MasterPassword, MasterPasswordConfirm);
        if (!isValidatePassword)
        {
            _dialogManager.ShowMessageBox("Пароли не совпадают!",
                                             "ошибка данных",
                                             MessageBoxImage.Error);
            return;
        }

        bool isNameCorrect = ModelAPI.CheckName(Name);
        if (!isNameCorrect)
        {
            _dialogManager.ShowMessageBox("Некорректное имя!",
                                             "ошибка данных",
                                             MessageBoxImage.Error);
            return;
        }

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
        dialog.InitialDirectory = Path;

        bool? result = dialog.ShowDialog();

        if (result == true)
        {
            Path = dialog.FolderName;
        }
    }
    private void SwitchPasswordVisibility(object obj)
    {
        if (IsShown)
        {
            PasswordToShow = MasterPassword;
        }
        else
        {
            MasterPassword = PasswordToShow;
            PasswordToShow = string.Empty;
        }
    }
}
