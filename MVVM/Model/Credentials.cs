using System.Net;

namespace Password_Manager.MVVM.Model;

public class Credentials : NetworkCredential {
    public string? desription;

    public Credentials (string? userName, string? password, string? domain, string? desription)
           : base(userName, password, domain) {
        this.desription = desription;
    }
}