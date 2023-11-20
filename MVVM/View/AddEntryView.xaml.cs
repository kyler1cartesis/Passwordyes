using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddEntryView.xaml
    /// </summary>
    public partial class AddEntryView : UserControl
    {
        public AddEntryView(AddEntryVM addEntryVM)
        {
            InitializeComponent();
            this.DataContext = addEntryVM;
        }
    }
}
