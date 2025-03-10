using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Integrations.Models;

namespace Integrations.Interfaces.Repositories
{
    public interface IAuthRepository
    {

        public AuthUserEntity Login(LoginModel loginModel);
        public bool Register(AuthUserEntity user);
    }
}
