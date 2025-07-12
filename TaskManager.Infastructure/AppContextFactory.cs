using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infastructure
{
    public class AppContextFactory:IDesignTimeDbContextFactory<AppContextClass>
    {
        public AppContextClass CreateDbContext(string[] args)
        {
            var optionBuilder=new DbContextOptionsBuilder<AppContextClass>();
            optionBuilder.UseSqlServer("Server=DESKTOP-FNRTGVK\\IRINA;Database=TaskManadjerDb;Trusted_Connection=True;TrustServerCertificate=True;");
            return new AppContextClass(optionBuilder.Options);
        }
    }
}
