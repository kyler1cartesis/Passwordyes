using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для CreateEntryForm.xaml
    /// </summary>
    public partial class EntryDataView : UserControl, IPasswordSupplier
    {
        public EntryDataView()
        {
            InitializeComponent();
        }

        public string GetPassword()
        {
            return passwordBox.Password;
        }

        public string GetPasswordConfirm()
        {
            return string.Empty;
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

            if((bool)isChecked)
                passwordBox.Visibility = Visibility.Collapsed;
            else
                passwordBox.Visibility = Visibility.Visible;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo { FileName = e.Uri.AbsoluteUri, UseShellExecute = true });
            }
            catch
            {

            }
            e.Handled = true;
        }
    }
}
