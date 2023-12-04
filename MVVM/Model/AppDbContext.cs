using Password_Manager.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Password_Manager.MVVM.Model;

internal class AppDbContext {
    private DBDescriptionVM? selectedDb;
    private DbManager dbManager;
    private byte[]? masterKey;
    private byte[]? publicKey;
    private Folder? dataRoot;
    public Folder? DataRoot { get; }

    public AppDbContext (DbManager dbManager) => this.dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));

    internal void SignInDb (DBDescriptionVM dbToSignIn) {
        if (!dbManager.CheckDbExistence(dbToSignIn)) throw new ArgumentException();
        selectedDb = dbToSignIn;
        LoadData();
    }

    static readonly JsonSerializerOptions jsonOptions = new() { IncludeFields = true, MaxDepth = 7, WriteIndented = true };
    internal void LoadData () {
        using FileStream file = StaticFileManager.OpenDbForRead(selectedDb.Name);
        //(publicKey, dataRoot) = JsonSerializer.Deserialize<DatabaseStructure>(file, jsonOptions);
        var j = JsonSerializer.Deserialize<DatabaseStructure>(file, jsonOptions);
    }

    internal void SaveData () {
        using FileStream file = StaticFileManager.OpenDbForWrite(selectedDb.Name);
        JsonSerializer.Serialize(file, new DatabaseStructure(publicKey, dataRoot), jsonOptions);
    }

    internal void CreateNewDB (string name, string masterPassword) {
        using FileStream file = StaticFileManager.CreateAndOpenDb(name);
        var db = new DatabaseStructure(Encoding.UTF8.GetBytes(masterPassword), new Folder());
        JsonSerializer.Serialize(file, db, jsonOptions);
    }

    internal void VerifyMPW () {
        throw new NotImplementedException();
    }

    internal void SaveMPW () {
        throw new NotImplementedException();
    }

    internal bool СreateEntry (string login, string password, string domain, string? desription) {
        if (!(StaticValidator.ValidateLogin(login) && StaticValidator.ValidatePassword(password)))
            return false;
        dataRoot.Add(new Entry() {
            Name = login,
            Password = password,
            Url = domain,
            Description = desription
        });
        SaveData();
        return true;
    }

    internal void Close () {
        SaveData();
        selectedDb = null;
        dataRoot = null;
        masterKey = null; publicKey = null;
    }

    public void ClearClipBoard () => StaticClipBoard.ClearClipBoard();

    public void CopyPasswordToClipboard (int id)
        => StaticClipBoard.CopyToClipboard(((Entry) dataRoot[id]).Password);

    public void CopyLoginToClipboard (int id)
        => StaticClipBoard.CopyToClipboard(((Entry) dataRoot[id]).Name);

    public void CopyDomainToClipboard (int id)
        => StaticClipBoard.CopyToClipboard(((Entry) dataRoot[id]).Url);

    public void OpenWebPage ()
        => throw new NotImplementedException();
}