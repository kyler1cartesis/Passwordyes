using System;

namespace Password_Manager.MVVM.Model;

public class DbContext
{
    private string _dbName;
    private string _masterPassword;
    internal object SQL_Execute(string query)
    {
        throw new NotImplementedException();
    }
}