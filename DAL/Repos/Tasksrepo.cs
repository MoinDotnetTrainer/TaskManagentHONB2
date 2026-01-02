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
        public async Task<List<Models.UsersTask>> GetAllTasks()
        {
            // var tasks = await _appdb.UsersTasks.ToListAsync();
            var tasks = await _appdb.UsersTasks
       .Include(t => t.AssignedUser)   // FK → PK
       .ToListAsync();
            return tasks;
        }

        public List<UsersTask> GetAllTasksByStatus(string Status)
        {
            return (from s in _appdb.UsersTasks.Include(t => t.AssignedUser) where s.Status == Status select s).ToList();
        }
    }
}
