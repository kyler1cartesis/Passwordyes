using System;
using System.IO;

namespace Password_Manager.MVVM.Model;

public static class DbManager {
    private const string DBsPath = "/databases/";

    public static string[] GetDbList ()
        => Directory.GetFiles("/databases");

    internal static FileStream OpenDbForRead (string FileName)
       => File.Open(DBsPath + FileName, FileMode.Open, FileAccess.Read);

    internal static FileStream OpenDbForWrite (string FileName)
       => File.Open(DBsPath + FileName, FileMode.Open, FileAccess.ReadWrite);

    internal static FileStream CreateAndOpenDb (string FileName)
       => File.Open(DBsPath + FileName, FileMode.CreateNew);

    internal static bool ValidateDb () {
        throw new NotImplementedException();
    }
}