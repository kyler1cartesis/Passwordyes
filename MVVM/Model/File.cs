using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Password_Manager.MVVM.Model
{
    public class File
    {
        private int path;

        private string _name; // Добавил временно, нужно для реализцаии интерфейса

        public string Name { get { return _name; } set { _name = value; } }

        public void GetPath()
        {
            throw new NotImplementedException();
        }
    }
}