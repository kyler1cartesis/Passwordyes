using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.MVVM.Model
{
    public class ModelAPI
    {
        public static ObservableCollection<DBDescription> GetDBDescriptions()
        {
            throw new NotImplementedException();
        }

        public static void CreateNewDB(DBDescription dBDescription)
        {
            throw new NotImplementedException();
        }

        public static void CreateNewDB(string Name, string MasterPassword)
        {
            throw new NotImplementedException();
        }

        public static bool ValidatePassword(DBDescription DbToSignIn, string MasterPassword)
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

        public static void RemoveDB(DBDescription selectedDBD)
        {
            throw new NotImplementedException();
        }
    }
}
