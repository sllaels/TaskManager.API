using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain;
namespace TaskManager.Infastructure.RepositoryClasses
{
    public class UserRepository:IUser
    {
       private readonly AppContextClass appContextClass;
        public UserRepository(AppContextClass appContextClass)
        {
            this.appContextClass = appContextClass;
        }
       public async Task<IEnumerable<User>> GetAllAsync()=>await appContextClass.Users.ToListAsync();
        public async Task AddAsync(User user) => await appContextClass.Users.AddAsync(user);

        public void UpDate(User user)=>appContextClass.Users.Update(user);
        public void Delete(User user)=>appContextClass.Users.Remove(user);

        public  async Task<User?> GetByIdAsync(int id)=>await appContextClass.Users.FindAsync(id);

       public  async Task<User?> GetByEmailAsync(string email)=>await appContextClass.Users.FirstOrDefaultAsync(e=>e.Email == email);   
       public async Task SaveChangesAsync()=>await appContextClass.SaveChangesAsync();


    }
}
