using Password_Manager.MVVM.ViewModel;
using System;
using System.Collections.ObjectModel;

namespace Password_Manager.MVVM.Model;
internal class ModelAPI : IModelAPI {
    private DbManager dbManager;
    private AppDbContext appDbContext;

    public ModelAPI () {
        dbManager = new();
        appDbContext = new(dbManager);
    }

    public void Exit ()
        => appDbContext.Close();

    public ObservableCollection<DBDescriptionVM> GetDBDescriptions ()
        => dbManager.GetDbDescriptions();

    public bool ValidatePassword (string masterPassword, string masterPasswordConfirm)
        => StaticValidator.ValidatePassword(masterPassword);

    public void CreateNewDB (string Name, string MasterPassword)
        => appDbContext.CreateNewDB(Name, MasterPassword);

    public void RemoveDB (DBDescriptionVM selectedDb)
        => dbManager.RemoveDb(selectedDb);

    public void SignInDb (DBDescriptionVM dbToSignIn)
        => appDbContext.SignInDb(dbToSignIn);

    public bool VerifyPassword (DBDescriptionVM DbToSignIn, string MasterPassword)
        => throw new NotImplementedException();

    public IEntryOrFolderVM GetRootFolder ()
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

    static void Main(string[] args) {
        // test
        ModelAPI modelAPI = new();
        modelAPI.CreateNewDB("test", "test");
        modelAPI.SignInDb(modelAPI.GetDBDescriptions()[0]);
        var gg = modelAPI.appDbContext.AuthorizationEntries;
        Console.WriteLine(gg);
        modelAPI.Exit();
    }
}
