using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrations.Models;

namespace Integrations.Interfaces.Repositories
{
    public interface IAuthRepository
    {

        public string Login(LoginModel loginModel);
        public string Register();
    }
}
