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
using Password_Manager.MVVM.Model;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для DataBasesView.xaml
    /// </summary>
    public partial class DataBasesView : UserControl
    {
        public DataBasesView()
        {
            InitializeComponent();
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListView list = UserList;
            DBDescription desc = list.SelectedItem as DBDescription;
            DataBasesViewModel.DBDescriptions.Remove(desc);
        }

        private void Button_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            ListView list = UserList;
            DBDescription desc = list.SelectedItem as DBDescription;
            MessageBox.Show(desc.DataBaseName);
        }
    }
}
