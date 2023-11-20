using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel
{
    public class FilesEditForm : ObservableObject
    {
        public DataBaseContextVM DBContext { get; set; }
        public string Name {  get; set; }
    }
}
