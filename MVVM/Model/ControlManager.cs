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

        public void BindDataContextToControl<T, V>(T control, V viewModel) where T : UserControl, new() 
                                                                           where V : ObservableObject
        {
            control.DataContext = viewModel;
        }

        public T CreateWindow<T>() where T : Window, new()
        {
            return new T();
        }
    }
}
