using System;
using System.Text.Json;
using System.Collections.Generic;
using Password_Manager.MVVM.ViewModel;
using System.IO;
using System.Text.Json.Serialization;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using Password_Manager.MVVM.Model.Static_Helpers;

namespace Password_Manager.MVVM.Model;

public class DbContext
{
    private DBDescriptionVM _description;
    private FolderVM? _rootFolder;
    private JsonSerializerOptions _options;
    private byte[] _masterPassword;
    public FolderVM? RootFolder
    {
        get => _rootFolder;
    }
    
    public DbContext(DBDescriptionVM desc, string password)
    {
        _description = desc;
        _masterPassword = Encoding.UTF8.GetBytes(password);
        _options = new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        DeserializeFileSystem();
    }

    public void DeserializeFileSystem()
    {
        var json = File.ReadAllText(_description.GetFullPathToFile());

        FolderVM? rootFolder = JsonSerializer.Deserialize<FolderVM?>(json, _options);
        if (rootFolder != null)
            _rootFolder = rootFolder;
    }

    public void SerializeFileSystem()
    {
        string json = JsonSerializer.Serialize(_rootFolder, _options);
       
        File.WriteAllText(_description.GetFullPathToFile(), json);
    }

    public byte[] EncryptPassword(string Password)
    {
        byte[] pwd = Encryptor.AES_Encrypt(Encoding.UTF8.GetBytes(Password), _masterPassword);

        return pwd;
    }

    public string DecryptPassword(byte[] Password)
    {
        byte[] pwd = Encryptor.AES_Decrypt(Password, _masterPassword);

        return Encoding.UTF8.GetString(pwd);
    }
}