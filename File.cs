using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Password_Manager
{
    public class File
    {
        private global::System.Int32 path;

        private string _name; // Добавил временно, нужно для реализцаии интерфейса

        public string Name { get { return _name; } set { _name = value; } }

        public void GetPath()
        {
            throw new System.NotImplementedException();
        }
    }
}