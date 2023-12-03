using System.Windows.Controls;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.View;

/// <summary>
/// Логика взаимодействия для CreateEntryForm.xaml
/// </summary>
public partial class EntryDataView : UserControl {
    public EntryDataView (EntryDataVM createEntry) {
        InitializeComponent();
        this.DataContext = createEntry;
    }
}
