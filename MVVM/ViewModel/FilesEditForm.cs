using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel;

public class FilesEditForm : ObservableObject {
    public RelayCommand CloseFormCommand { get; set; }
    public DataBaseContextVM DBContext { get; set; }

    protected string _name;
    public string Name {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }

    public FilesEditForm () {
        CloseFormCommand = new RelayCommand(CloseForm);
    }

    private void CloseForm (object obj) {
        DBContext.ClosePage();
    }
}
