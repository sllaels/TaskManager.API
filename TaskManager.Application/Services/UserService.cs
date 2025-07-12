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

namespace TaskManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private IJwtService jwtService;
        private IUser user;
        public UserService(IJwtService jwtService,IUser user,ILogger<UserService> _logger)
        {
            this.jwtService = jwtService;
            this.user = user;
            this._logger = _logger;
        }
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var existen = await user.GetByEmailAsync(request.Email);
            if (existen != null)
            {
                return false;
            }
            User us = new User
            {
                Email=request.Email,
                Name = request.Name,
                Password = request.Password
            };
            await user.AddAsync(us);
            await user.SaveChangesAsync();
            return true;
        }
        public async Task<string?> LoginAsync(RegisterRequest request)
        {
            try
            {
                var _user = await user.GetByEmailAsync(request.Email);
                if (_user == null)
                {
                    return null;
                }

                return jwtService.GeneratToken(_user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при логине");
                throw;
            }
        }
    }
}

