using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.MVVM.ViewModel;

namespace Password_Manager.MVVM.Model
{
    public class ModelAPI
    {
        //Возвращает актульный список баз данных в системе
        public static ObservableCollection<DBDescriptionVM> GetDBDescriptions()
        {
            return DbManager.GetObservableDescriptions();
        }

        //Создаёт в системе новую БД с указанным именем и паролем
        public static void CreateNewDB(DBDescriptionVM description, string Password)
        {
            DbManager.CreateNewDB(description, Password);
        }

       
        //Сверяет пароль для входа в БД
        public static bool VerifyPassword(DBDescriptionVM DbToSignIn, string MasterPassword)
        {
            return DbManager.VerifyPassword(DbToSignIn, MasterPassword);
        }

        //Проверяет название БД
        public static bool Validate_DB_Name(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && !string.IsNullOrEmpty(name);
        }

        //Проверяет введённые пользователем пароли на корректность и совпадение
        public static bool ValidatePassword(string masterPassword, string masterPasswordConfirm)
        {
            return masterPassword.Equals(masterPasswordConfirm);
        }

        //Удаляет БД из системы
        public static void RemoveDB(DBDescriptionVM selectedDBD)
        {
            DbManager.RemoveDB(selectedDBD);
        }

        //Входит в БД и начинает сессию работы с БД
        public static void SignInBD(DBDescriptionVM dbToSignIn, string MasterPassword)
        {
            DbManager.SignInDb(dbToSignIn, MasterPassword);
        }

        //Возвращает корневую директорию БД
        public static FolderVM? GetRootFolder()
        {
            return DbManager.DBContext?.RootFolder;
        }

        //Выходит из БД и завершает сессию UPD : Думаю просто один раз считать из json'а всю стуктуру и передать во VM, всю логику проще будет написать там,
        //так ка VM слишком прирос в этом смысле к логике
        public static void Exit()
        {
            DbManager.Exit();
        }

        //Проверяет корректность описания записи
        public static bool ValidateEntryDescription(string description)
        {
            throw new NotImplementedException();
        }

        //Проверяет корректность url-адреса
        public static bool VaildateEntruURL(string uRL)
        {
            throw new NotImplementedException();
        }

        //Зашифровать пароль и вернуть (не обязательно в виде string, можно поменять тип любой объект)
        internal static byte[] EncryptEntryPassword(string password)
        {
            if (DbManager.DBContext != null)
                return DbManager.DBContext.EncryptPassword(password);
            else
                return [];
        }

        //Дешифровать зашифрованный пароль
        internal static string DecryptEntryPassword(byte[] password)
        {
            if (DbManager.DBContext != null)
                return DbManager.DBContext.DecryptPassword(password);
            else
                return string.Empty;
        }

        internal static void CopyPasswordToClipBoard(byte[] encryptedPassword)
        {
            System.Windows.Clipboard.SetText(DecryptEntryPassword(encryptedPassword));
        }

        internal static void UpdateDescription(DBDescriptionVM description)
        {
            DbManager.UpdateObservableDescriptions(description);
        }

        internal static bool CheckPassword(string masterPassword)
        {
            return !string.IsNullOrEmpty(masterPassword) && masterPassword.Length < 64 && !string.IsNullOrWhiteSpace(masterPassword);
        }

        internal static bool CheckName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length < 64 && !string.IsNullOrWhiteSpace(name);
        }
    }
}
