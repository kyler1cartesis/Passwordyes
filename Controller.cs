using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Password_Manager;

// Controller - комментарий просто для лабы
// Create test branch
// Changes in new branch
public class Controller
{
    private View view;
    private MainWindow mainWindow;
    private AppDbContext appDbContext;
    readonly private System.Collections.Generic.List<System.Net.NetworkCredential> AuthorizationEntries;

    public void OnOpenDbList () {
        throw new System.NotImplementedException();
    }

    public void OnNewDb () {
        throw new System.NotImplementedException();
    }

    public void OnDataSend () {
        throw new System.NotImplementedException();
    }

    public void OnDbCreate () {
        throw new System.NotImplementedException();
    }

    public void OnDbSelect () {
        throw new System.NotImplementedException();
    }

    public void OnMPW_Entered () {
        throw new System.NotImplementedException();
    }

    public void OnSearchFieldUpdate (string search) {
        throw new System.NotImplementedException();
    }

    private void SearchEntries () {
        throw new System.NotImplementedException();
    }

    public void CreateEntry () {
        throw new System.NotImplementedException();
    }

    private bool ValidateEntry () {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnURLClick()
    {
        throw new System.NotImplementedException();
    }
}