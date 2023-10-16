using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace Password_Manager;

public class AppDbContext
{
    private DbContext dbContext;
    private Hash masterKey;
    private Hash publicKey;

    internal Hash MasterKey {
        get => default;
        set {
        }
    }

    public Hash PublicKey {
        get => default;
        set {
        }
    }

    internal void VerifyMPW () {
        throw new System.NotImplementedException();
    }

    internal void SaveMPW () {
        throw new System.NotImplementedException();
    }

    internal List<System.Net.NetworkCredential> GetData () {
        throw new System.NotImplementedException();
    }

    internal bool СreateEntry (string login, Hash hashedPassword) {
        throw new System.NotImplementedException();
    }

    private void RetrievePublicKey () {
        throw new System.NotImplementedException();
    }

    public void Close()
    {
        throw new System.NotImplementedException();
    }

    public void ClearClipBoard()
    {
        throw new System.NotImplementedException();
    }

    public void CopeToClipBoard()
    {
        throw new System.NotImplementedException();
    }

    public void OpenWebPage()
    {
        throw new System.NotImplementedException();
    }
}