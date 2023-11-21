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
        public RelayCommand CloseFormCommand { get; set; }
        public DataBaseContextVM DBContext { get; set; }
        public string Name {  get; set; }

        public FilesEditForm() 
        { 
            CloseFormCommand = new RelayCommand(CloseForm);
        }

        private void CloseForm(object obj)
        {
            DBContext.ClosePage();
        }
    }
}
