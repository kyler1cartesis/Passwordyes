using System;
using System.IO;

namespace Password_Manager.MVVM.Model;

public static class StaticFileManager {
    private const string DBsPath = "databases/";
    private const string extension = ".json";

    public static string[] GetDbFileNames ()
       => Directory.GetFiles(DBsPath, $"*{extension}");

    private static string GetRelDbPath (string fileName)
       => Path.Combine(DBsPath, fileName) + extension;

    internal static FileStream OpenDbForRead (string fileName)
       => File.Open(GetRelDbPath(fileName), FileMode.Open, FileAccess.Read);

    internal static FileStream OpenDbForWrite (string fileName)
       => File.Open(GetRelDbPath(fileName), FileMode.Open, FileAccess.ReadWrite);

    internal static FileStream CreateAndOpenDb (string fileName) {
        if (!Directory.Exists(DBsPath)) Directory.CreateDirectory(DBsPath);
        return File.Open(GetRelDbPath(fileName), FileMode.CreateNew);
    }

    internal static void DeleteDb (string fileName)
       => File.Delete(GetRelDbPath(fileName));

    internal static bool ValidateDb () {
        throw new NotImplementedException();
    }
}