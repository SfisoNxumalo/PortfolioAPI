using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrations.Interfaces.Repositories;
using Infrastructure.Data;
using Integrations.Models;
using Domain.Entities;
using Integrations.CustomExceptions;

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
            try
            {
                var user = _dbContext.AuthUser.FirstOrDefault(
                    user => user.Email == loginModel.email && user.Password == loginModel.password
                );

                return user;
            }
            catch {
                throw new DatabaseException("An unexpected error occurred while trying to find the user");
            }
            

        }

        public bool Register(AuthUserEntity user)
        {
            try
            {
                var UserFound = _dbContext.AuthUser.FirstOrDefault(
                    users => user.Email == users.Email
                );

                if (UserFound != null)
                {
                    throw new DatabaseException("A user with this email address already exists");
                }

                _dbContext.AuthUser.Add(user);
                _dbContext.SaveChanges();

                return true;
            }
            catch {
                throw new DatabaseException("An unexpected error occurred while trying to register user");
            }
        }
    }
}
