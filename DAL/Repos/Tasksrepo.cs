using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class Tasksrepo : ITask
    {
        public readonly AppDatabase _appdb;
        public Tasksrepo(AppDatabase appdb)
        {
            _appdb = appdb;
        }
        public async Task CreateTask(Models.UsersTask task)
        {
            await _appdb.UsersTasks.AddAsync(task);
            await _appdb.SaveChangesAsync();
        }
    }
}
