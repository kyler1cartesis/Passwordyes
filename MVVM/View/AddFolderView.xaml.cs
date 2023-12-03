using System.Windows.Controls;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.View;

/// <summary>
/// Логика взаимодействия для AddFolderView.xaml
/// </summary>
public partial class AddFolderView : UserControl {
    public AddFolderView (AddFolderVM addFolder) {
        InitializeComponent();
        this.DataContext = addFolder;
    }
}
