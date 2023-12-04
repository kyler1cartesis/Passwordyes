using System.Windows;

namespace Password_Manager.MVVM.Model;
public static class StaticClipBoard {

    public static void ClearClipBoard () => Clipboard.Clear();

    public static void CopyToClipboard (string s)
        => Clipboard.SetText(s);
}