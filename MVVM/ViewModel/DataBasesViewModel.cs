﻿using System;
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
            DBDescriptions.Add(dBDescription);
        }

        //Коллекция БД
        public static ObservableCollection<DBDescription> DBDescriptions { get; set; } = new ObservableCollection<DBDescription>();

        //Выбранная БД на данный момент времени
        public DBDescription SelectedDBD { get; set; }

        //Команда отображения формы ввода данных новой БД
        public ICommand ShowWindowCommand { get; set; }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;
            AddDB addDBWin = new AddDB(mainWindow);
            addDBWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addDBWin.Show();
        }

        private void GetDBDs()
        {
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

        public DataBasesViewModel()
        {
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

            DBDescriptions = new ObservableCollection<DBDescription>();

            GetDBDs();
        }
    }
}