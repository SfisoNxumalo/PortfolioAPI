﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.JwtService.Interfaces
{
    public interface ITokenService
    {
        public string EncodeToken(string Uid);
    }
}
