using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Integrations.Interfaces.Repositories;
using Integrations.Models;
using Integrations.Repository;
using Services.DTO;
using Services.Interfaces.Services;
using Services.JwtService.Interfaces;
using Services.ServiceExceptions;

namespace Services.Services.Authentication
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepo;
        private readonly ITokenService _tokenService;
        public AuthService(IAuthRepository authRepo, ITokenService tokenService) {
            _authRepo = authRepo;
            _tokenService = tokenService;
        }
        public string Login(LoginModel loginModel)
        {

            if (loginModel == null)
            {
                throw new NoContentException("Email and password are required");
            }

            if (string.IsNullOrWhiteSpace(loginModel.email) || string.IsNullOrWhiteSpace(loginModel.password))
            {
                throw new NoContentException(
                   string.IsNullOrWhiteSpace(loginModel.email) ? "Email is required" : "Password is required"
                );
            }

            var user = _authRepo.Login(loginModel);

            if (user == null)
            {
                throw new NotFoundException("A user with the entered details was not found");
            }

            var encodedToken = _tokenService.EncodeToken(user.Uid);

            return encodedToken;
            
        }

        public bool Register(RegisterDTO userEntity)
        {
            if (userEntity == null)
            {
                throw new NoContentException("Email and password are required");
            }

            if (string.IsNullOrWhiteSpace(userEntity.Email) || string.IsNullOrWhiteSpace(userEntity.Password))
            {
                throw new NoContentException("Please insert all the required fields");
            }

            if (string.IsNullOrEmpty(userEntity.Uid))
            {
                userEntity.Uid = Convert.ToString(Guid.NewGuid())!;
            }

            var NewUser = new AuthUserEntity
            {
                Uid = userEntity.Uid,
                Email = userEntity.Email,
                Password = userEntity.Password
            };

            var userRegistered = _authRepo.Register(NewUser);

            if (!userRegistered)
            {
                throw new NotFoundException("User registration failed");
            }

            return true;
        }
    }
}
