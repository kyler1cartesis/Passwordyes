using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel
{
    public class DataBaseContextVM
    {
        private DbContext _context;

        public string CurrentFolderName
        {
            get
            {
                return CurrentFolder.Name;
            }
        }

        public ObservableCollection<File> CurrentSubFiles { get; set; } = new ObservableCollection<File>();
        public File CurrentFolder { get; set; }= new File();
        public File SelectedFolder { get; set; } = new File();

        public DbContext Context { get { return _context; } }

        public string DbName { get; set; }

        public DataBaseContextVM()
        {
            DbContext context = new DbContext();
            _context = context;
        }
    }
}
