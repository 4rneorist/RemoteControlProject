﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RemoteControl.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Move(int direction)
        {
            int maxSpeed = 30;
            int error;
            string filePathInfo = Directory.GetCurrentDirectory() + "/wwwroot/information.txt";
            int x, y, speed;
            using (StreamReader file = new StreamReader(filePathInfo, true))
            {
                file.ReadLine();
                speed = Int32.Parse(file.ReadLine());
                x = Int32.Parse(file.ReadLine());
                y = Int32.Parse(file.ReadLine());
                error = Int32.Parse(file.ReadLine());
            }
            if (error != -1)
            {
                switch (direction)
                {
                    case 0:
                        y -= speed;
                        break;
                    case 1:
                        x += speed;
                        break;
                    case 2:
                        x -= speed;
                        break;
                    case 3:
                        y += speed;
                        break;
                    case 4:
                        if (speed <= maxSpeed)
                            speed++;
                        break;
                    case 5:
                        if (speed > 0)
                            speed--;
                        break;
                    case -1:
                        speed = 0;
                        break;
                }
            }
            else
            {
                speed = 0;
            }
            string filePath = Directory.GetCurrentDirectory() + "/wwwroot/control.txt";
            using (StreamWriter file = new StreamWriter(filePath, false))
            {
                file.WriteLine(direction);
                file.WriteLine(speed);
            }
            using (StreamWriter file = new StreamWriter(filePathInfo, false))
            {
                file.WriteLine(direction);
                file.WriteLine(speed);
                file.WriteLine(x);
                file.WriteLine(y);
                file.WriteLine(error);
            }
            return RedirectToAction("PlatformControll");
        }
        [Authorize(Roles = "admin")]
        public ViewResult Index()
        {
            //using (RemoteControlContext db = new RemoteControlContext())
            //{
            //    db.Database.EnsureCreated();
            //    User u1 = new User();
            //    u1.Email = "root@root.root";
            //    u1.Username = "root";
            //    u1.Password = "root";
            //    Role r1 = new Role();
            //    r1.Name = "admin";
            //    u1.Role = r1;
            //    db.Roles.Add(r1);
            //    db.Users.Add(u1);
            //    db.SaveChanges();
            //}
            return View("Main");
            
        }
        [Authorize(Roles = "admin")]
        public ViewResult PlatformControll()
        {
            string direction;
            string error;
            string filePath = Directory.GetCurrentDirectory() + "/wwwroot/information.txt";
            using (StreamReader file = new StreamReader(filePath, true))
            {
                direction = file.ReadLine();
                ViewBag.speed = file.ReadLine();
                ViewBag.x = file.ReadLine();
                ViewBag.y = file.ReadLine();
                error = file.ReadLine();

            }
            ViewBag.error = error;
            switch (direction)
            {
                case "1":
                    ViewBag.currentDirection = "Move Right";
                    break;
                case "2":
                    ViewBag.currentDirection = "Move Left";
                    break;
                case "3":
                    ViewBag.currentDirection = "Move Front";
                    break;
                case "0":
                    ViewBag.currentDirection = "Move Back";
                    break;
                case "4":
                    ViewBag.currentDirection = "Speed Up";
                    break;
                case "5":
                    ViewBag.currentDirection = "Speed Down";
                    break;
                case "-1":
                    ViewBag.currentDirection = "Stop";
                    break;
            }
            return View();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Accounting");
        }


        
    }
}
