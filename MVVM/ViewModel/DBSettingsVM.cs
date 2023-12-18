using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Password_Manager.Core;
using Password_Manager.MVVM.Model;

namespace Password_Manager.MVVM.ViewModel
{
    public class DBSettingsVM : ObservableObject
    {
        public DBDescriptionVM Description { get; set; }

        public ICommand ConfirmCommand { get; set; }

        private string _validChars;
        public string ValidChars
        {
            get => _validChars;
            set { _validChars = value; OnPropertyChanged(nameof(ValidChars)); }
        }

        private string _message;
        public string Message
        {
            get => _message;
            set { _message = value; OnPropertyChanged(nameof(Message)); }
        }

        private int _length;
        public int Length
        {
            get => _length;
            set { _length = value; OnPropertyChanged(nameof(Length)); }
        }

        public DBSettingsVM() 
        {
            ConfirmCommand = new RelayCommand(SaveChanges);

            if (DbManager.DBContext == null) 
            {
                Description = new DBDescriptionVM();
                _validChars = string.Empty;
                _length = 1;
                _message = string.Empty;

                return;
            }

            Description = DbManager.DBContext.Description;

            _validChars = Description.CharsForPwdGenerator;
            _length = Description.PasswordLength;
            _message = string.Empty;
        }

        private void SaveChanges(object obj)
        {
            Description.PasswordLength = _length;
            Description.CharsForPwdGenerator = _validChars;

            ModelAPI.UpdateDescription(Description);

            Message = "Настройки сохранены";
        }
    }
}
