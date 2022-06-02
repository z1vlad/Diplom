using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        public async Task<IEnumerable<User>> GetAll()
        {
            using (var db = new vladDBContext())
                return await db.User.ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            using (var db = new vladDBContext())
                return await db.User.FirstOrDefaultAsync(u => u.UserId == id);
        }
        public async Task<User> GetByNumber(string number)
        {
            using (var db = new vladDBContext())
                return await db.User.FirstOrDefaultAsync(u => u.Number == number);
        }
        public async Task<IEnumerable<User>> GetByName(string name)
        {
            using (var db = new vladDBContext())
            {
                var users = db.User.ToList();
                return users.Where(u => u.FIO() == name || u.FI() == name || u.IO() == name || u.Surname == name || u.Name == name || u.Patronymic == name);
            }
        }
        public async Task<int> Create(User user)
        {
            using (var dbContext = new vladDBContext())
            {
                await dbContext.User.AddAsync(user);
                await dbContext.SaveChangesAsync();
                return user.UserId;
            }
        }
        public async Task Update(User user)
        {
            using (var dbContext = new vladDBContext())
            {
                dbContext.User.Update(user);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task Delete(User user)
        {
            using (var dbContext = new vladDBContext())
            {
                dbContext.User.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }

}
