using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.Model
{
    public class ModelAPI
    {
        public static ObservableCollection<DBDescriptionVM> GetDBDescriptions()
        {
            throw new NotImplementedException();
        }

        public static void CreateNewDB(string Name, string MasterPassword)
        {            
            throw new NotImplementedException();
        }

        public static bool ValidatePassword(DBDescriptionVM DbToSignIn, string MasterPassword)
        {
            throw new NotImplementedException();
        }

        public static bool Validate_DB_Name(string name)
        {
            throw new NotImplementedException();
        }

        public static bool Validate_DB_MPassword(string masterPassword)
        {
            throw new NotImplementedException();
        }

        public static void RemoveDB(DBDescriptionVM selectedDBD)
        {
            throw new NotImplementedException();
        }
    }
}
