using Microsoft.AspNetCore.Mvc;
using MJ_JewelleryMVC.Models;

namespace MJ_JewelleryMVC.Controllers
{
    public class UsersController : Controller
    {
        UsersModel objusers = new UsersModel();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsersModel.signin users)
        {
            bool res;
            if (ModelState.IsValid)
            {
                objusers = new UsersModel();
                res = objusers.login(users);
                if (res)
                {
                    TempData["msg"] = "Login successfully";
                }
            else
            {
                TempData["msg"] = "Not Login. something went wrong..!!";

            }
            }
            return View();
            
        }

        [HttpPost]
        public IActionResult Register(UsersModel.Register users)
        {
            bool res;
            if (ModelState.IsValid)
            {
                objusers = new UsersModel();
                res = objusers.register(users);
                if (res)
                {
                    TempData["msg"] = "Register successfully";
                }

                else
                {
                    TempData["msg"] = "Not Register. something went wrong..!!";

                }
            }
            return View();

        }
    }
}
