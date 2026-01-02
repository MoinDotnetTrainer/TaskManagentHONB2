using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsers
    {
        Task CreateUser(User user);

        bool ValidateUser(string Email, string Password);

        Task<List<User>> GetAllUsers();  // is for Dropdown

        Task<List<UsersTask>> GetAllUsersTaskByID(int UserId);

        Task<int> GetUserIDByEmail(string EmailID);
        Task UpdateStatusAsync(int TaskId, string Status);

        Task<UsersTask> GetTaskByTaskID(int TaskId);  // is for Dropdown
    }
}
