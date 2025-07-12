using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using TaskManager.Domain;
namespace TaskManager.Infastructure
{
    public class AppContextClass:DbContext
    {
      public  DbSet<User> Users => Set<User>();
      public   DbSet<TaskEntity>Tasks=> Set<TaskEntity>();
      public  DbSet<Category> Categories => Set<Category>();
      public AppContextClass(DbContextOptions<AppContextClass> options) : base(options) { }

    }
}
