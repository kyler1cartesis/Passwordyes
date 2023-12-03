﻿using System;
using System.Windows;

namespace Password_Manager.MVVM.View;

/// <summary>
/// Логика взаимодействия для SignInDataBaseWindow.xaml
/// </summary>
public partial class SignInDataBaseWindow : Window {

    public SignInDataBaseWindow (Window mainWindow) {
        InitializeComponent();
        Owner = mainWindow;
        this.Owner.IsEnabled = false;
    }
    private void Window_Closed (object sender, EventArgs e) {
        this.Owner.IsEnabled = true;
    }

    private void CloseForm (object sender, RoutedEventArgs e) {
        this.Close();
    }
}
