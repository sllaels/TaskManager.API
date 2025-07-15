using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace TaskManager.Application.Services
{
    public class WorkWithCurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public WorkWithCurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected int GetCurrentUserId()
        {
            var stringUserId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (stringUserId == null)

                throw new UnauthorizedAccessException("Пока не зарегистрирован");

            if (!int.TryParse(stringUserId, out int userId))
                throw new Exception("User ID в токене имеет неверный формат.");
            return userId;
        }
    }
}
