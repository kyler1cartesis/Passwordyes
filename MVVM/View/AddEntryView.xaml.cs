using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для AddEntryView.xaml
    /// </summary>
    public partial class AddEntryView : UserControl, IPasswordSupplier
    {
        public AddEntryView()
        {
            InitializeComponent();
        }

        public string GetPassword()
        {
            return passwordBox.Password;
        }

        public string GetPasswordConfirm()
        {
            return passwordBox.Password;
        }

        public void SetPassword(string password)
        {
            passwordBox.Password = password;
        }

        private void hide_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton btn = (ToggleButton)sender;
            bool? isChecked = btn.IsChecked;
            if (isChecked == null) throw new NullReferenceException("isChecked was null while toggle button click");

            if ((bool)isChecked)
            {
                passwordBox.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Visible;
            }
            else
            {
                passwordBox.Visibility = Visibility.Visible;
                textBox.Visibility= Visibility.Collapsed;
            }
        }
    }
}
