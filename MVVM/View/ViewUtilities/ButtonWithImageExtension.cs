using System.Windows;
using System.Windows.Media;

namespace Password_Manager.MVVM.View.ViewUtilities;

public static class ButtonWithImageExtension {
    public static ImageSource GetImage (DependencyObject obj) {
        return (ImageSource) obj.GetValue(ImageProperty);
    }

    public static void SetImage (DependencyObject obj, ImageSource image) {
        obj.SetValue(ImageProperty, image);
    }

    public static readonly DependencyProperty ImageProperty = DependencyProperty.RegisterAttached(
                                                                                                 "Image",
                                                                                                 typeof(ImageSource),
                                                                                                 typeof(ButtonWithImageExtension));
}
