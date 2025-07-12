using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Contracts;
namespace TaskManager.Application.ServiceInterfaces
{
    public interface ICategoryService
    {
        Task CreateCaterogyAsync(CategoryRequest request);
    }
}
