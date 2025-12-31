using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagentHONB2.Models;

namespace TaskManagentHONB2.Controllers
{
    public class TaskingController : Controller
    {
        public readonly ITask _task;
        public readonly IUsers _user;
        public TaskingController(ITask task, IUsers user)
        {
            _task = task;
            _user = user;
        }


        [HttpGet]
        public async Task<IActionResult> AddTask()
        {

            //on load get list of users from db and send to viewbag
            ViewBag.userlist = new SelectList(await _user.GetAllUsers(), "UserId", "Username"); // getting id ,username ,email , password
            //                                              from all Users data , Userid and username , username id for UI and Userid is for backend    
            return View();
        }


        [HttpPost]
        public IActionResult AddTask(UsersTask obj)
        {
            if (ModelState.IsValid)
            {
                _task.CreateTask(obj);
                return RedirectToAction("TaskList");
            }
            return View();
        }


        [HttpGet]
        public IActionResult TaskList()
        {

            return View();
        }
    }
}
