namespace Password_Manager.MVVM.Model;

public record DatabaseStructure {
    public readonly byte[] PublicKey;
    public readonly Folder DataRoot;

    internal void Deconstruct (out byte[] publicKey, out Folder authorizationEntries)
        => (publicKey, authorizationEntries) = (PublicKey, DataRoot);

    public DatabaseStructure (byte[] publicKey, Folder authorizationEntries) {
        PublicKey = publicKey;
        DataRoot = authorizationEntries;
    }
}