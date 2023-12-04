using Password_Manager.MVVM.ViewModel;
using System.Collections.Generic;

namespace Password_Manager.MVVM.Model;

public record DatabaseStructure {
    public readonly byte[] PublicKey;
    public readonly List<IEntryOrFolderVM> AuthorizationEntries;

    internal void Deconstruct (out byte[] publicKey, out List<IEntryOrFolderVM> authorizationEntries)
        => (publicKey, authorizationEntries) = (PublicKey, AuthorizationEntries);

    public DatabaseStructure (byte[] publicKey, List<IEntryOrFolderVM> authorizationEntries) {
        PublicKey = publicKey;
        AuthorizationEntries = authorizationEntries;
    }
}