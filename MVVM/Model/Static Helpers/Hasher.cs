using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace Password_Manager.MVVM.Model;

public static class StaticHasher
{
    public static Hash GetHash(string input)
    {
        throw new NotImplementedException();
    }

    public static Hash EncryptPassword(string password, Hash public_key)
    {
        throw new NotImplementedException();
    }

    public static (Hash, Hash) GenerateSecretAndPublicKey() => throw new NotImplementedException();

    public static bool CheckPassword(string password, Hash hash)
    {
        throw new NotImplementedException();
    }
}