using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace Password_Manager;

public static class StaticHasher
{
    public static Hash GetHash (string input) {
        throw new System.NotImplementedException();
    }

    public static Hash EncryptPassword (string password, System.Security.Policy.Hash public_key) {
        throw new System.NotImplementedException();
    }

    public static (Hash, Hash) GenerateSecretAndPublicKey () => throw new System.NotImplementedException();

    public static bool CheckPassword (string password, Hash hash) {
        throw new System.NotImplementedException();
    }
}