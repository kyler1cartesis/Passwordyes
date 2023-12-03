using System.Windows.Controls;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.View;

/// <summary>
/// Interaction logic for SignInDBView.xaml
/// </summary>
public partial class SignInDBView : UserControl, IPasswordSupplier {
    public SignInDBView () {
        InitializeComponent();
    }

    public string GetPassword () {
        return passwordBox.Password;
    }

    public string GetPasswordConfirm () {
        return passwordBox.Password;
    }

    public void SetPassword (string password) {
        return;
    }
}
