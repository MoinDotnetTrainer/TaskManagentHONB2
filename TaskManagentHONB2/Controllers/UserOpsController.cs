using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
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
                Username = obj.Username,  // lhs is DAL.Models.User, rhs is TaskManagentHONB2.Models.User
                Password = obj.Password,
                Email = obj.Email
            };
            if (obj == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                await _iuser.CreateUser(user);
                return RedirectToAction("Login");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                bool isValidUser = _iuser.ValidateUser(obj.Email, obj.Password);
                int myusers = await _iuser.GetUserIDByEmail(obj.Email);  // user id ,6
                if (obj.Email == "admin@yahoo.com" && obj.Password == "admin")
                {
                    return RedirectToAction("AdminHomePage");
                }
                else
                {
                    if (isValidUser)
                    {
                        HttpContext.Session.SetInt32("UserID", myusers);


                        return RedirectToAction("UserHomePage");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserHomePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminHomePage()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> TaskList()
        {
            int? AssignedUserId = HttpContext.Session.GetInt32("UserID");
            if (AssignedUserId == null)
            {
                return View();
            }
            var users = await _iuser.GetAllUsersTaskByID(AssignedUserId.Value);
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int TaskId)
        {
            return View(await _iuser.GetTaskByTaskID(TaskId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(UsersTask obj)
        {
            await _iuser.UpdateStatusAsync(obj.TaskId, obj.Status);
            return RedirectToAction("TaskList");
        }

    }
}
