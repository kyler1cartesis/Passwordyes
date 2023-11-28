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
            throw new NotImplementedException();
        }

        //Создаёт в системе новую БД с указанным именем и паролем
        public static void CreateNewDB(string Name, string MasterPassword)
        {            
            throw new NotImplementedException();
        }

       
        //Сверяет пароль для входа в БД
        public static bool VerifyPassword(DBDescriptionVM DbToSignIn, string MasterPassword)
        {
            throw new NotImplementedException();
        }

        //Проверяет название БД
        public static bool Validate_DB_Name(string name)
        {
            throw new NotImplementedException();
        }

        //Проверяет введённые пользователем пароли на корректность и совпадение
        public static bool ValidatePassword(Tuple<string, string> masterPassword)
        {
            throw new NotImplementedException();
        }

        //Удаляет БД из системы
        public static void RemoveDB(DBDescriptionVM selectedDBD)
        {
            throw new NotImplementedException();
        }

        //Входит в БД и начинает сессию работы с БД
        public static void SignInBD(DBDescriptionVM dbToSignIn)
        {
            throw new NotImplementedException();
        }

        //Возвращает корневую директорию БД
        public static FileVM GetRootFolder()
        {
            throw new NotImplementedException();
        }

        //Выходит из БД и завершает сессию
        public static void Exit()
        {
            throw new NotImplementedException();
        }

        //Подняться в родительскую директорию текщуей директории
        public static void ClimbUp()
        {
            throw new NotImplementedException();
        }

        //Спуститься в дочернюю директорию текущей папки
        public static void GoIntoTheFolder(string name)
        {
            throw new NotImplementedException();
        }

        //Удалить файл из текущей директории по имени
        public static void RemoveFileByName(string name)
        {
            throw new NotImplementedException();
        }

        //Вернуть актуальный список файлов в текущей директории
        public static ObservableCollection<FileVM> UpdateFileList()
        {
            throw new NotImplementedException();
        }

        //Создать в текущей директории новыую папку
        public static void CreatNewFolder(string name)
        {
            throw new NotImplementedException();
        }

        //Создаёт новую запись в текущей директории
        public static void CreateNewEntry(string name, string description, string uRL, string item1)
        {
            throw new NotImplementedException();
        }

        //Изменяет запись в текущей директории
        public static void ChangeEntry(string oldName, string name, string description, string uRL, string password)
        {
            throw new NotImplementedException();
        }

        //Проверяет корректность описания записи
        public static bool ValidateEntryDescription(string description)
        {
            throw new NotImplementedException();
        }

        //Проверяет корректность пароля записи
        public static bool ValidateEntryPassword(Tuple<string, string> password)
        {
            throw new NotImplementedException();
        }

        //Проверяет корректность имени папки/записи
        public static bool ValidateFileName(string name)
        {
            throw new NotImplementedException();
        }

        //Проверяет корректность url-адреса
        public static bool VaildateEntruURL(string uRL)
        {
            throw new NotImplementedException();
        }
    }
}
