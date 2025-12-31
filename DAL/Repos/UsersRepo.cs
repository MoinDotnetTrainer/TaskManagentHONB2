using DAL.Interfaces;
using DAL.Models;
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
    }
}
