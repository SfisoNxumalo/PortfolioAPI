using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrations.Interfaces.Repositories;
using Infrastructure.Data;
using Integrations.Models;
using Domain.Entities;

namespace Integrations.Repository
{
    public class AuthRepository : IAuthRepository
    {

        private readonly DatabaseContext _dbContext;
        public AuthRepository(DatabaseContext _dbContext) {
            this._dbContext = _dbContext;
        }

        public AuthUserEntity Login(LoginModel loginModel)
        {
            var user = _dbContext.AuthUser.FirstOrDefault(
                user => user.Email == loginModel.email && user.Password == loginModel.password
            );

            return user;

        }

        public string Register()
        {
            throw new NotImplementedException();
        }
    }
}
