using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TaskManager.Domain.Interfaces
{
    public interface IUser:IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
      
    }
}
