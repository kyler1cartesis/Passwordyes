﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.MVVM.Model
{
    public interface IPasswordSupplier
    {
        Tuple<string, string> GetPassword();
    }
}
