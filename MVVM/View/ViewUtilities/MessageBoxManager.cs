using System.Windows;

namespace Password_Manager.MVVM.View.ViewUtilities;

public static class MessageBoxManager {
    public static MessageBoxResult ShowMessageBox (string message, string title, MessageBoxImage image) {
        return MessageBox.Show(message, "PasswordStorm : " + title, GetButton(image), image);
    }

    private static MessageBoxButton GetButton (MessageBoxImage image) {
        return image switch {
            MessageBoxImage.Error => MessageBoxButton.OK,
            MessageBoxImage.Warning => MessageBoxButton.YesNoCancel,
            MessageBoxImage.Question => MessageBoxButton.YesNo,
            MessageBoxImage.Information => MessageBoxButton.OKCancel,
            _ => MessageBoxButton.OK,
        };
    }
}
