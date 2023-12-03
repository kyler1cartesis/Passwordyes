using System.Windows.Controls;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.View;

/// <summary>
/// Логика взаимодействия для AddEntryView.xaml
/// </summary>
public partial class AddEntryView : UserControl, IPasswordSupplier {
    public AddEntryView () {
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
