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
    /// Логика взаимодействия для ChangeEntryView.xaml
    /// </summary>
    public partial class ChangeEntryFormView : UserControl, IPasswordSupplier
    {
        public ChangeEntryFormView()
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
    }
}
