using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Contracts;

namespace TaskManager.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<string?> LoginAsync(RegisterRequest request);
    }
}
