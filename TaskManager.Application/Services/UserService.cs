using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Domain.Interfaces;
using TaskManager.Contracts;
using TaskManager.Application.ServiceInterfaces;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace TaskManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private IJwtService jwtService;
        private IUser userRepository;
        public UserService(IJwtService jwtService,IUser user,ILogger<UserService> _logger)
        {
            this.jwtService = jwtService;
            this.userRepository = user;
            this._logger = _logger;
        }
        private string PasswordHasher(string password)
        {
          var hash=new PasswordHasher<User>();
            var passwordHasher = hash.HashPassword(new User(), password);
            return passwordHasher;
        }
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var existen = await userRepository.GetByEmailAsync(request.Email);
            if (existen != null)
            {
                return false;
            }
            User us = new User
            {
                Email=request.Email,
                Name = request.Name,
                Password = PasswordHasher(request.Password)
            };
            await userRepository.AddAsync(us);
            await userRepository.SaveChangesAsync();
            return true;
        }
        public async Task<string?> LoginAsync(LoginRequest request)
        {
            try
            {
                var exsistUser = await userRepository.GetByEmailAsync(request.Email);
                if (exsistUser == null)
                {
                    _logger.LogWarning("Попытка входа с несуществующим email: {Email}", request.Email);
                    return null;
                }

                var hash = new PasswordHasher<User>();
                var result = hash.VerifyHashedPassword(exsistUser,exsistUser.Password,request.Password);
                if(result==PasswordVerificationResult.Failed)
                {
                    _logger.LogWarning("Неверный пароль для пользователя: {Email}", request.Email);
                    return null;
                }
                return jwtService.GeneratToken(exsistUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при логине");
                throw;
            }
        }
    }
}

