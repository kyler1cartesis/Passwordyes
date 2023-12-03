using Isopoh.Cryptography.Argon2;
using System;
using System.Security.Policy;

namespace Password_Manager.MVVM.Model;

public static class StaticHasher {
    public static Isopoh.Cryptography.SecureArray.SecureArray<byte> GetHash (string input) {
        var hasher = new Argon2(new Argon2Config());
        return hasher.Hash();
        throw new NotImplementedException();
    }

    public static Hash EncryptPassword (string password, Hash public_key) {
        throw new NotImplementedException();
    }

    public static (Hash, Hash) GenerateSecretAndPublicKey () => throw new NotImplementedException();

    public static bool CheckPassword (string password, Hash hash) {
        throw new NotImplementedException();
    }
}