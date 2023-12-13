using System;
using System.Collections.Generic;
using System.IO;
using Password_Manager.MVVM.ViewModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace Password_Manager.MVVM.Model;

public static class DbManager
{
    private static string JsonPath = "D:/kopos/GitHub/Passwordyes/ProjectFiles/DataBases.json";
    private static List<DBDescriptionVM> _descriptionVM = new List<DBDescriptionVM>();

    public static List<DBDescriptionVM> DescriptionsVM { get => _descriptionVM; }

    public static DbContext? DBContext { get; set; }

    public static void DeserializeDataBases()
    {
        var json = File.ReadAllText(JsonPath);

        List<DBDescriptionVM>? descriptions = JsonConvert.DeserializeObject<List<DBDescriptionVM>?>(json);
        if(descriptions != null)
            _descriptionVM = descriptions;
    }

    public static void SerializeDataBases()
    {
        string json = JsonConvert.SerializeObject(_descriptionVM);
        File.WriteAllText(JsonPath, json);
    }

    public static ObservableCollection<DBDescriptionVM> GetObservableDescriptions()
    {
        DeserializeDataBases();

        return new ObservableCollection<DBDescriptionVM>(_descriptionVM);
    }

    public static void CreateNewDB(DBDescriptionVM description, string Password)
    {
        description.UniqueName = GenerateUniqueName(description);

        CreateDbFile(description);

        _descriptionVM.Add(description);

        byte[] hasedPassword = GetBytesIn_UTF8_Encoding(Password);
        description.HashedPassword = HashPasswordSHA256(hasedPassword);

        SerializeDataBases();
    }

    private static string GenerateUniqueName(DBDescriptionVM desc)
    {
        string name = desc.DataBaseCreateDate.Second.ToString();
        name += desc.DataBaseCreateDate.Minute.ToString();
        name += desc.DataBaseCreateDate.Hour.ToString();
        name += desc.DataBaseCreateDate.Month.ToString();

        int counter = 0;
        while (IsContainsDbWithName(name))
        {
            counter++;
        }

        name += counter.ToString();
        return name;
    }

    private static bool IsContainsDbWithName(string Name)
    {
        return _descriptionVM.Any(x => x.UniqueName.Equals(Name));
    }

    public static void RemoveDB(DBDescriptionVM description)
    {
        RemoveDbFile(description);

        _descriptionVM.RemoveAll(dsc => dsc.Name.Equals(description.Name));

        SerializeDataBases();
    }

    private static void CreateDbFile(DBDescriptionVM desc)
    {
        FolderVM RootFolder = new FolderVM(null, desc.Name + "-root");
        string json = JsonConvert.SerializeObject(RootFolder);

        File.WriteAllText(desc.GetFullPathToFile(), json);
    }

    private static void RemoveDbFile(DBDescriptionVM desc)
    {
        File.Delete(desc.GetFullPathToFile());
    }

    public static byte[] GetBytesIn_UTF8_Encoding(string password)
    {
        return Encoding.UTF8.GetBytes(password);
    }
    public static byte[] HashPasswordSHA256(byte[] passwordBytes)
    {
        return SHA256.Create().ComputeHash(passwordBytes);
    }

    public static void SignInDb(DBDescriptionVM desc, string MasterPassword)
    {
        DBContext = new DbContext(desc, MasterPassword);
    }

    internal static FileStream OpenDbForRead (string FileName)
       => System.IO.File.Open("/databases/" + FileName, FileMode.Open, FileAccess.Read);
    
    internal static FileStream OpenDbForWrite (string FileName)
       => System.IO.File.Open("/databases/" + FileName, FileMode.Open, FileAccess.ReadWrite);

    internal static bool VerifyPassword(DBDescriptionVM DbToSignIn, string MasterPassword)
    {
        return HashPasswordSHA256(GetBytesIn_UTF8_Encoding(MasterPassword)).SequenceEqual(DbToSignIn.HashedPassword);
    }

    internal static void Exit()
    {
        DBContext?.SerializeFileSystem();
        DBContext = null;
    }
}