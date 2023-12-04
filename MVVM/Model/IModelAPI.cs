using System;
using System.Collections.ObjectModel;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.Model;

internal interface IModelAPI {

    //Возвращает актуальный список баз данных в системе
    internal ObservableCollection<DBDescriptionVM> GetDBDescriptions ();

    //Создаёт в системе новую БД с указанным именем и паролем
    internal void CreateNewDB (string Name, string MasterPassword);

    //Сверяет пароль для входа в БД
    internal bool VerifyPassword (DBDescriptionVM DbToSignIn, string MasterPassword);

    //Проверяет название БД
    internal bool ValidateDbName (string name);

    //Проверяет введённые пользователем пароли на корректность и совпадение
    internal bool ValidatePassword (string masterPassword, string masterPasswordConfirm);

    //Удаляет БД из системы
    internal void RemoveDB (DBDescriptionVM selectedDBD);

    //Входит в БД и начинает сессию работы с БД
    internal void SignInDb (DBDescriptionVM dbToSignIn);

    //Возвращает корневую директорию БД
    internal IEntryOrFolderVM GetRootFolder ();

    //Выходит из БД и завершает сессию
    internal void Exit ();

    //Проверяет корректность описания записи
    internal bool ValidateEntryDescription (string description);

    //Проверяет корректность пароля записи
    internal bool ValidateEntryPassword (Tuple<string, string> password);

    //Проверяет корректность имени папки/записи
    internal bool ValidateFileName (string name);

    //Проверяет корректность url-адреса
    internal bool ValidateEntryURL (string uRL);
}
