using Password_Manager.MVVM.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Password_Manager.MVVM.Model;

internal class DbManager {
    private ObservableCollection<DBDescriptionVM> DbDescriptions;

    internal ObservableCollection<DBDescriptionVM> GetDbDescriptions () {
        UpdateDbDescriptions();
        return DbDescriptions;
    }

    internal void RemoveDb (DBDescriptionVM selectedDb) {
        UpdateDbDescriptions();
        if (!CheckDbExistence(selectedDb)) throw new ArgumentException();
        StaticFileManager.DeleteDb(selectedDb.Name);
        DbDescriptions.Remove(selectedDb);
    }

    private void UpdateDbDescriptions () {
        string[] fileNames = StaticFileManager.GetDbFileNames();
        DbDescriptions = new();
        for (int i = 0; i < fileNames.Length; i++)
            DbDescriptions.Add(new DBDescriptionVM() {
                Name = Path.GetFileNameWithoutExtension(fileNames[i]),
                DataBaseLastOpenDate = File.GetLastWriteTime(fileNames[i]),
                DataBaseCreateDate = File.GetCreationTime(fileNames[i]),
                Level = CodeLevel.HIGH,
            });
    }
    
    internal bool CheckDbExistence (DBDescriptionVM selectedDb) {
        return DbDescriptions.Contains(selectedDb);
    }
}