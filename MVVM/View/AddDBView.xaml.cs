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
    /// Interaction logic for AddDBView.xaml
    /// </summary>
    public partial class AddDBView : UserControl, IPasswordSupplier
    {
        public AddDBView()
        {
            InitializeComponent();
        }

        public string GetPassword()
        {
            return firstBox.Password;
        }

        public string GetPasswordConfirm()
        {
            return secondBox.Password;
        }

        public void SetPassword(string password)
        {
            return;
        }
    }
}
