using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.View;

namespace Password_Manager.MVVM.ViewModel
{
    class DataBasesViewModel : ObservableObject
    {
        //Добавление новой БД в список
        public static void AddDBD(DBDescription dBDescription)
        {
            //ModelAPI.AddNewDB(dBDescription);
            //UpdateDBDs();

            DBDescriptions.Add(dBDescription);
        }

        //Коллекция БД
        public static ObservableCollection<DBDescription> DBDescriptions { get; set; } = new ObservableCollection<DBDescription>();

        //Выбранная БД на данный момент времени
        public DBDescription SelectedDBD { get; set; }

        //Команда отображения формы ввода данных новой БД
        public ICommand ShowWindowCommand { get; set; }
        public ICommand ShowSignInDbWindowCommand { get; set; }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private bool CanShowSignInDBWindow(object obj)
        {
            return SelectedDBD != null;
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;
            AddDBWindow addDBWin = new AddDBWindow(mainWindow);
            addDBWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addDBWin.Show();
        }

        private void ShowSignInDBWindow(object obj)
        {
            var mainWindow = obj as Window;
            SignInDBVM signInDBVM = new SignInDBVM();
            signInDBVM.DbToSignIn = SelectedDBD;
            SignInDataBaseWindow signInDBWindow = new SignInDataBaseWindow(mainWindow);
            signInDBWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            signInDBWindow.DataContext = signInDBVM;
            signInDBWindow.Show();
        }

        private static void UpdateDBDs()
        {

            //DBDescriptions = ModelAPI.GetDBDescriptions();

            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №1",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });

            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.HIGH
            });

            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.MID
            });
            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now,
                Level = CodeLevel.HIGH
            });
            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
        }

        public DataBasesViewModel()
        {
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

            ShowSignInDbWindowCommand = new RelayCommand(ShowSignInDBWindow, CanShowSignInDBWindow);

            DBDescriptions = new ObservableCollection<DBDescription>();

            UpdateDBDs();
        }
    }
}
