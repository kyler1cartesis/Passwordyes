using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Password_Manager.Core;
using Unity;

namespace Password_Manager.MVVM.Model
{
    public class ControlManager
    {
        public IUnityContainer RegisterControl<T>(T control) where T : IPasswordSupplier
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterInstance<IPasswordSupplier>(control);
            return container;
        }

        public T CreateControl<T>() where T : UserControl, new()
        {
            return new T();
        }
        public T CreateWindow<T>() where T : Window, new()
        {
            return new T();
        }

        public void BindDataContextToControl<T, V>(T control, V viewModel) where T : UserControl
                                                                           where V : ObservableObject
        {
            control.DataContext = viewModel;
        }
        public void BindDataContextToWindow<T, V>(T window, V viewModel) where T : Window
                                                                         where V : ObservableObject
        {
            window.DataContext = viewModel;
        }

        public void ShowWindowAtCenter<T>(T window) where T : Window
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }
        public void CloseWindow<T>(T window) where T : Window
        {
            window.Close();
        }
    }
}
