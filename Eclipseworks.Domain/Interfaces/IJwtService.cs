﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Domain.Interfaces;

public interface IJwtService
{
    string GenerateToken(int userid, string email);
}
