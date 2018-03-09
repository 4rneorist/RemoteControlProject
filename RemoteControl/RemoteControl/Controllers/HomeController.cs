using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using RemoteControl.Models;

namespace RemoteControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Move(int direction)
        {
            return RedirectToAction("PlatformControll");
        }
        public ViewResult Index()
        {
            return View("Main");
        }

        public ViewResult PlatformControll()
        {
            return View();
        }

        public ViewResult LogOut()
        {
            return View("Main");
        }


        
    }
}
