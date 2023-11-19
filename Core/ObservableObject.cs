using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Core
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if(PropertyChanged == null)
            {
                Debug.WriteLine("Prop is null");
            }
            else
            {
                Debug.WriteLine("Invoke");
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
