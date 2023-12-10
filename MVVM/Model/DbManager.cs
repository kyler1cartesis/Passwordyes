using System;
using System.Collections.Generic;
using System.IO;
using Password_Manager.MVVM.ViewModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;
using System.Security.Cryptography;

namespace Password_Manager.MVVM.Model;

public static class DbManager
{
    private static string JsonPath = "D:/kopos/GitHub/Passwordyes/ProjectFiles/DataBases.json";
    private static List<DBDescriptionVM> _descriptionVM = new List<DBDescriptionVM>();

    public static List<DBDescriptionVM> DescriptionsVM { get => _descriptionVM; }

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
        _descriptionVM.Add(description);

        byte[] hasedPassword = GetBytesIn_UTF8_Encoding(Password);
        description.HashedPassword = HashPasswordSHA256(hasedPassword);

        SerializeDataBases();
    }

    public static byte[] GetBytesIn_UTF8_Encoding(string password)
    {
        return Encoding.UTF8.GetBytes(password);
    }
    public static byte[] HashPasswordSHA256(byte[] passwordBytes)
    {
        return SHA256.Create().ComputeHash(passwordBytes);
    }

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