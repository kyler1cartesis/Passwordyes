using System;
using System.IO;

namespace Password_Manager.MVVM.Model;

public static class DbManager
{
    public static string[] GetDbList()
        => Directory.GetFiles("/databases");

    internal static FileStream OpenDbForRead (string FileName)
       => System.IO.File.Open("/databases/" + FileName, FileMode.Open, FileAccess.Read);
    
    internal static FileStream OpenDbForWrite (string FileName)
       => System.IO.File.Open("/databases/" + FileName, FileMode.Open, FileAccess.ReadWrite);

    internal static FileStream CreateAndOpenDb (string FileName)
       => System.IO.File.Open("/databases/" + FileName, FileMode.CreateNew);
    
    internal static bool ValidateDb() {
        throw new NotImplementedException();
    }
}