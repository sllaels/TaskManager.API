using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.ServiceInterfaces
{
    public interface IJwtService
    {
        string GeneratToken(User user);
    }
}
