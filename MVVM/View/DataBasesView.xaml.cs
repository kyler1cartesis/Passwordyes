using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.View;

/// <summary>
/// Логика взаимодействия для DataBasesView.xaml
/// </summary>
public partial class DataBasesView : UserControl {
    public DataBasesView () {
        InitializeComponent();
    }

    private void UserList_SelectionChanged (object sender, SelectionChangedEventArgs e) {

    }

    /*private void RemoveDB(object sender, MouseButtonEventArgs e)
    {
        ListView list = UserList;
        DBDescription desc = list.SelectedItem as DBDescription;
        DataBasesViewModel.DBDescriptions.Remove(desc);
    }*/

    private void SignInDB (object sender, MouseButtonEventArgs e) {
        ListView list = UserList;
        DBDescriptionVM desc = list.SelectedItem as DBDescriptionVM;
        MessageBox.Show(desc.Name);
    }

}
