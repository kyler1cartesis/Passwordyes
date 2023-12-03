using System.ComponentModel;

namespace Password_Manager.Core;

public class ObservableObject : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged (string propName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
