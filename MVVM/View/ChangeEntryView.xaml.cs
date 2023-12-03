using System.Windows.Controls;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.View;

/// <summary>
/// Логика взаимодействия для ChangeEntryView.xaml
/// </summary>
public partial class ChangeEntryView : UserControl, IPasswordSupplier {
    public ChangeEntryView () {
        InitializeComponent();
    }

    public string GetPassword () {
        return passwordBox.Password;
    }

    public string GetPasswordConfirm () {
        return passwordBox.Password;
    }

    public void SetPassword (string password) {
    }
}
