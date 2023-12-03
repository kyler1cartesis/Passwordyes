using System;
using System.Collections.ObjectModel;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.Model;

public class ModelAPI {
    //Возвращает актульный список баз данных в системе
    public static ObservableCollection<DBDescriptionVM> GetDBDescriptions () {
        throw new NotImplementedException();
    }

    //Создаёт в системе новую БД с указанным именем и паролем
    public static void CreateNewDB (string Name, string MasterPassword) {
        throw new NotImplementedException();
    }


    //Сверяет пароль для входа в БД
    public static bool VerifyPassword (DBDescriptionVM DbToSignIn, string MasterPassword) {
        throw new NotImplementedException();
    }

    //Проверяет название БД
    public static bool Validate_DB_Name (string name) {
        throw new NotImplementedException();
    }

    //Проверяет введённые пользователем пароли на корректность и совпадение
    public static bool ValidatePassword (string masterPassword, string masterPasswordConfirm) {
        throw new NotImplementedException();
    }

    //Удаляет БД из системы
    public static void RemoveDB (DBDescriptionVM selectedDBD) {
        throw new NotImplementedException();
    }

    //Входит в БД и начинает сессию работы с БД
    public static void SignInBD (DBDescriptionVM dbToSignIn) {
        throw new NotImplementedException();
    }

    //Возвращает корневую директорию БД
    public static FileVM GetRootFolder () {
        throw new NotImplementedException();
    }

        //Выходит из БД и завершает сессию UPD : Думаю просто один раз считать из json'а всю стуктуру и передать во VM, всю логику проще будет написать там,
        //так ка VM слишком прирос в этом смысле к логике
        public static void Exit()
        {
            throw new NotImplementedException();
        }

        //Проверяет корректность описания записи
        public static bool ValidateEntryDescription(string description)
        {
            throw new NotImplementedException();
        }
            throw new NotImplementedException();
        }

        //Проверяет корректность описания записи
        public static bool ValidateEntryDescription(string description)
        {
            throw new NotImplementedException();
        }
            throw new NotImplementedException();
        }

        //Проверяет корректность описания записи
        public static bool ValidateEntryDescription(string description)
        {
            throw new NotImplementedException();
        }
            throw new NotImplementedException();
        }

        //Проверяет корректность описания записи
        public static bool ValidateEntryDescription(string description)
        {
            throw new NotImplementedException();
        }

    //Проверяет корректность пароля записи
    public static bool ValidateEntryPassword (Tuple<string, string> password) {
        throw new NotImplementedException();
    }

    //Проверяет корректность имени папки/записи
    public static bool ValidateFileName (string name) {
        throw new NotImplementedException();
    }

    //Проверяет корректность url-адреса
    public static bool VaildateEntruURL (string uRL) {
        throw new NotImplementedException();
    }
}
