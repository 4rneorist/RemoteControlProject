using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Models;
using RemoteControl.Models.AccountingModels;

namespace RemoteControl.Controllers
{
    public class AccountingController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                using (RemoteControlContext db = new RemoteControlContext())
                {
                    User user = await db.Users
                        .Include(u => u.Role)
                        .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);
                    if (user != null)
                    {
                        await Authenticate(user);

                        return RedirectToAction("Index","Home");
                    }

                    ModelState.AddModelError("", "Incorrect login and(or) password");
                }
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}