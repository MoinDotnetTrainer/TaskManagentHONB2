using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITask
    {
        Task CreateTask(Models.UsersTask task);
        //Task<List<Models.UsersTask>> GetTasksByUserId(int userId);
        //Task<Models.UsersTask> GetTaskById(int taskId);
        //Task UpdateTask(Models.UsersTask task);
        //Task DeleteTask(int taskId);
    }
}
