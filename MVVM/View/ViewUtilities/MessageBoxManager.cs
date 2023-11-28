using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Password_Manager.MVVM.View.ViewUtilities
{
    public static class MessageBoxManager
    {
        public static MessageBoxResult ShowMessageBox(string message, string title, MessageBoxImage image)
        {
            return MessageBox.Show(message, "PasswordStorm : " + title, GetButton(image), image);
        }

        private static MessageBoxButton GetButton(MessageBoxImage image)
        {
            switch (image)
            {
                case MessageBoxImage.Error:
                    return MessageBoxButton.OK;
                case MessageBoxImage.Warning:
                    return MessageBoxButton.YesNoCancel;
                case MessageBoxImage.Question:
                    return MessageBoxButton.YesNo;
                case MessageBoxImage.Information:
                    return MessageBoxButton.OKCancel;
                default: return MessageBoxButton.OK;
            }
        }
    }
}
