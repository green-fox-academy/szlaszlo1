﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anagramm.Services
{
    public interface IAnagramChecker
    {
        bool CheckForAnagramm(string s);
    }
}
