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
        public static void AddDBD(DBDescription dBDescription)
        {
            DBDescriptions.Add(dBDescription);
        }
        public static ObservableCollection<DBDescription> DBDescriptions { get; set; } = new ObservableCollection<DBDescription>();

        public DBDescription SelectedDBD { get; set; }

        public ICommand ShowWindowCommand { get; set; }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;

            AddDB addDBWin = new AddDB();
            addDBWin.Owner = mainWindow;
            addDBWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addDBWin.Show();


        }

        public DataBasesViewModel()
        {
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

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
                DataBaseCreateDate = DateTime.Now
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
            DBDescriptions.Add(new DBDescription
            {
                DataBaseName = "Test DataBase №2",
                Status = "Open",
                DataBaseLastOpenDate = DateTime.Now,
                DataBaseCreateDate = DateTime.Now
            });
        }
    }
}
