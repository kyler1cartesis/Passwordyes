using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows;

namespace Password_Manager.MVVM.Model;

public class AppDbContext
{
    private DbContext dbContext;
    private Hash masterKey;
    private Hash publicKey;

    internal void VerifyMPW()
    {
        throw new NotImplementedException();
    }

    internal void SaveMPW()
    {
        throw new NotImplementedException();
    }

    internal List<System.Net.NetworkCredential> GetData()
    {
        throw new NotImplementedException();
    }

    internal bool СreateEntry(string login, Hash hashedPassword)
    {
        throw new NotImplementedException();
    }

    private void RetrievePublicKey()
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public void ClearClipBoard() => Clipboard.Clear();

    public void CopyToClipBoard()
    {
        //Clipboard.SetText();
    }

    public void OpenWebPage()
    {
        throw new NotImplementedException();
    }
}