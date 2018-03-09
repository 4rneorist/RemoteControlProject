using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RemoteControl.Models;

namespace RemoteControl.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where((r=>r.WillAttend==true)));
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
        }

        
    }
}
