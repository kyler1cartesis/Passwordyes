using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Password_Manager.MVVM.Model;

public static class DbManager
{
    public static string[] GetDbList()
        => Directory.GetFiles("/databases");

    internal static FileStream CreateAndOpenDb(string FileName)
       => System.IO.File.Open("/databases/" + FileName, FileMode.CreateNew);

    internal static bool ValidateDb()
    {
        throw new NotImplementedException();
    }
}