﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_001.Application.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(string email, string password);
    }
}
