using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Integrations.Models;

namespace Services.Interfaces.Services
{
    public interface IAuthService
    {

        public string Login(LoginModel loginModel);

        public bool Register(AuthUserEntity userEntity);
    }
}
