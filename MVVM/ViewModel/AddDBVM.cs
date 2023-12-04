using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View.ViewUtilities;
using Unity;

namespace Password_Manager.MVVM.ViewModel;

public class AddDBVM : ObservableObject {
    private MainViewModel _mainVM;
    //Команда добавления БД в коллекцию
    public ICommand AddDBCommand { get; set; }
    public ICommand CloseFormCommand { get; set; }
    public ICommand SetCodeLevelCommand { get; set; }

    private string _errorMessage;
    public string ErrorMessage {
        get => _errorMessage;
        set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
    }
    //Поле с именем новой БД
    private string _name;
    public string Name {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }

    //Поле с Мастер паролем новой БД
    private IUnityContainer _container;
    public string MasterPassword {
        get {
            IPasswordSupplier passwordSupplier = _container.Resolve<IPasswordSupplier>();
            return passwordSupplier.GetPassword();
        }
    }
    public string MasterPasswordConfirm {
        get {
            IPasswordSupplier passwordSupplier = _container.Resolve<IPasswordSupplier>();
            return passwordSupplier.GetPasswordConfirm();
        }
    }
    public CodeLevel Level { get; set; }


    public AddDBVM (MainViewModel mainVM, IUnityContainer container) {
        _mainVM = mainVM;
        _container = container;
        AddDBCommand = new RelayCommand(AddDB, CanAddDB);
        SetCodeLevelCommand = new RelayCommand(SetCodeLevel);
        CloseFormCommand = new RelayCommand(Close);
    }

    private bool CanAddDB (object obj) {
        //bool isValidateName = ModelAPI.Validate_DB_Name(Name);
        return true;
    }

    private void AddDB (object obj) {
        //bool isValidatePassword = ModelAPI.Validate_DB_MPassword(MasterPassword, MasterPasswordConfirm);
        //ModelAPI.CreateNewDB(Name, MasterPassword);

        _mainVM.DataBasesViewCommand.Execute(null);
        _mainVM.DataBasesVM.AddDBD(new DBDescriptionVM { Name = Name, DataBaseLastOpenDate = DateTime.Now, Level = Level });
    }

    private void Close (object obj) {
        var answer = MessageBoxManager.ShowMessageBox("Отменить создание базы данных?",
                                             "отмена создания БД",
                                             MessageBoxImage.Question);
        if (answer == MessageBoxResult.Yes)
            _mainVM.DataBasesViewCommand.Execute(null);
        else
            return;
    }

    private void SetCodeLevel (object obj) {
        if (obj is RadioButton button) {
            Level = button.Name switch {
                "low" => CodeLevel.LOW,
                "mid" => CodeLevel.MID,
                "high" => CodeLevel.HIGH,
                _ => throw new Exception("Wrong radio button name"),
            };
        }
    }
}
