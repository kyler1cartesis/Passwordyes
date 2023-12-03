using Password_Manager.MVVM.ViewModel;
using System;
using System.Collections.ObjectModel;

namespace Password_Manager.MVVM.Model;
internal class ModelAPI : IModelAPI {
    private View view;
    private MainWindow mainWindow;
    private AppDbContext appDbContext;

    public void CreateNewDB (string Name, string MasterPassword)
        => throw new NotImplementedException();

    public void Exit ()
        => appDbContext.Close();

    public ObservableCollection<DBDescriptionVM> GetDBDescriptions ()
        => appDbContext.GetDbDescriptions();

    public FileVM GetRootFolder ()
        => throw new NotImplementedException();

    public void RemoveDB (DBDescriptionVM selectedDBD)
        => throw new NotImplementedException();

    public void SignInDb (DBDescriptionVM dbToSignIn)
        => throw new NotImplementedException();

    public bool ValidateDbName (string name)
        => throw new NotImplementedException();

    public bool ValidateEntryDescription (string description)
        => throw new NotImplementedException();

    public bool ValidateEntryPassword (Tuple<string, string> password)
        => throw new NotImplementedException();

    public bool ValidateEntryURL (string uRL)
        => throw new NotImplementedException();

    public bool ValidateFileName (string name)
        => throw new NotImplementedException();

    public bool ValidatePassword (string masterPassword, string masterPasswordConfirm)
        => throw new NotImplementedException();

    public bool VerifyPassword (DBDescriptionVM DbToSignIn, string MasterPassword)
        => throw new NotImplementedException();
}
