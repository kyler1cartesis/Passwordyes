namespace Password_Manager.MVVM.Model;

public interface IPasswordSupplier {
    string GetPassword ();
    string GetPasswordConfirm ();
    void SetPassword (string password);
}
