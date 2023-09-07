﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp.Application.Common.Interfaces;
public interface ITokenGenerator
{
    string GenerateToken(string userId,string fullName, string userName, IList<string> roles);
}
