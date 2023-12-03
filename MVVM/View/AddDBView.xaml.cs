using System.Windows.Controls;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.View;

/// <summary>
/// Interaction logic for AddDBView.xaml
/// </summary>
public partial class AddDBView : UserControl, IPasswordSupplier {
    public AddDBView () {
        InitializeComponent();
    }

    public string GetPassword () {
        return firstBox.Password;
    }

    public string GetPasswordConfirm () {
        return secondBox.Password;
    }

    public void SetPassword (string password) {
        return;
    }
}
