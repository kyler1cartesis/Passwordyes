using System.Collections.Generic;
using System.Net;
using System.Security.Policy;

namespace Password_Manager.MVVM.Model;

public record DatabaseStructure {
    public readonly Hash PublicKey;
    public readonly List<Credentials> AuthorizationEntries;

    internal void Deconstruct (out Hash publicKey,out List<Credentials> authorizationEntries)
        => (publicKey, authorizationEntries) = (PublicKey, AuthorizationEntries);
    
    public DatabaseStructure (Hash publicKey,List<Credentials> authorizationEntries) {
        PublicKey = publicKey;
        AuthorizationEntries = authorizationEntries;
    }
}