using System;
using System.Collections.Generic;
using System.IO;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.Model;

public static class DbManager
{

    private static List<DBDescriptionVM> _descriptionVM = new List<DBDescriptionVM>();

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