using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UsersRepo : IUsers
    {
        public readonly AppDatabase _appdb;
        public UsersRepo(AppDatabase appdb)
        {
            _appdb = appdb;
        }
        public async Task CreateUser(Models.User user)
        {
            await _appdb.Users.AddAsync(user);
            await _appdb.SaveChangesAsync();
        }

        public bool ValidateUser(string _Email, string _Password)
        {
            var user = (from s in _appdb.Users select s).Any(x => x.Email == _Email && x.Password == _Password);
            if (user)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Models.User>> GetAllUsers()
        {
            var users = await _appdb.Users.ToListAsync();   
            return users;
        }
    }
}
