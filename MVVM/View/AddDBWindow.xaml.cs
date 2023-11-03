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
using System.Windows.Shapes;

namespace Password_Manager.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddDB.xaml
    /// </summary>
    public partial class AddDBWindow : Window
    {
        public AddDBWindow(Window mainWindow)
        {
            InitializeComponent();
            Owner = mainWindow;
            this.Owner.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.IsEnabled = true;
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
