using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using TaskManagentHONB2.Models;

namespace TaskManagentHONB2.Controllers
{
    public class UserOpsController : Controller
    {
        public readonly IUsers _iuser;
        public UserOpsController(IUsers iuser)
        {
            _iuser = iuser;
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(TaskManagentHONB2.Models.User obj)
        {

            DAL.Models.User user = new DAL.Models.User()
            {
                Username = obj.Username,
                Password = obj.Password,
                Email = obj.Email
            };
            if (obj == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid) // 
            {

                await _iuser.CreateUser(user);
            }
            return View();
        }
    }
}
