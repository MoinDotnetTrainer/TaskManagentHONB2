using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<UsersTask>> GetAllUsersTaskByID(int AssignedUserId)
        {
            var userTasks = await _appdb.UsersTasks.Where(x => x.AssignedUserId == AssignedUserId).ToListAsync();
            return userTasks;
        }

        public async Task<int> GetUserIDByEmail(string email)
        {
            return await _appdb.Users
                .Where(u => u.Email == email)
                .Select(u => u.UserId)
                .FirstOrDefaultAsync();
        }


        public async Task<UsersTask> GetTaskByTaskID(int TaskId)
        {
            var task = await _appdb.UsersTasks.FirstOrDefaultAsync(x => x.TaskId == TaskId);
            return task;
        }
        public async Task UpdateStatusAsync(int TaskId, string Status)
        {
            var task = new UsersTask
            {
                TaskId = TaskId,
                Status = Status
            };

            _appdb.UsersTasks.Attach(task);

            _appdb.Entry(task).Property(x => x.Status).IsModified = true;

            await _appdb.SaveChangesAsync();
        }

        

    }
}
