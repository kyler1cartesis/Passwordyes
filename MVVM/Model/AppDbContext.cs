using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text.Json;
using System.Windows;

namespace Password_Manager.MVVM.Model;

public class AppDbContext {
    private DbContext dbContext;
    private Hash? masterKey;
    private Hash? publicKey;
    private List<Credentials>? authorizationEntries;

    public Hash? PublicKey { get; }
    public List<Credentials>? AuthorizationEntries { get; }

    internal void VerifyMPW () {
        throw new NotImplementedException();
    }

    internal void SaveMPW () {
        throw new NotImplementedException();
    }

    internal void LoadData (string fileName) {
        using FileStream file = DbManager.OpenDbForRead(fileName);
        (publicKey, authorizationEntries) = JsonSerializer.Deserialize<DatabaseStructure>(file);
    }

    internal void SaveData (string fileName) {
        using FileStream file = DbManager.OpenDbForWrite(fileName);
        JsonSerializer.Serialize(file, new DatabaseStructure(publicKey, authorizationEntries));
    }

    internal bool СreateEntry (string login, string password, string? domain, string? desription) {
        if (!(StaticValidator.ValidateLogin(login) && StaticValidator.ValidatePassword(password)))
            return false;
        authorizationEntries.Add(new Credentials(login, password, domain, desription));
        return true;
    }

    internal void Close () {
        authorizationEntries = null;
        masterKey = null; publicKey = null;
    }

    public void ClearClipBoard () => Clipboard.Clear();

    public void CopyPasswordToClipboard (int id)
        => Clipboard.SetText(authorizationEntries[id].Password);

    public void CopyLoginToClipboard (int id)
        => Clipboard.SetText(authorizationEntries[id].UserName);

    public void CopyDomainToClipboard (int id)
        => Clipboard.SetText(authorizationEntries[id].Domain);

    public void OpenWebPage ()
        => throw new NotImplementedException();
}