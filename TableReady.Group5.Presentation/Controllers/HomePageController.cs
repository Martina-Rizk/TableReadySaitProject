/// <summary>
/// Home page controller
/// Author: Sohail Umer
/// Date: August 7, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TableReady.Group5.BLL;
using TableReady.Group5.Domain;
using TableReady.Group5.Presentation.Helper;
using TableReady.Group5.Presentation.Models;

namespace TableReady.Group5.Presentation.Controllers
{
    public class HomePageController : Controller
    {
        // Sohail---
        private readonly RewardManager rewardsManager;
        private readonly ISession session;
        public HomePageController(IHttpContextAccessor httpContextAccessor)
        {
            this.session = httpContextAccessor.HttpContext.Session;
            rewardsManager = new RewardManager();
        }

        public IActionResult Index()
        {
            var restaurant = RestaurantManager.GetAll();
            return View(restaurant);
        }

        // Sohail//
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // Sohail 
        [HttpPost]
        public IActionResult Login(CustomerLogin login)
        {
            if (ModelState.IsValid)
            {
                var result = rewardsManager.Login(login.UserName, login.Password);
                if (result != null)
                {
                    SessionHelper.SetObjectAsJson(this.session, "User", result);
                    return RedirectToAction("RewardPage", "Dashboard");
                }
                else
                    ViewBag.Msg = "Invalid UserName or Password";
            }

            return View();
        }
        //Sohail...
        [HttpGet]
        public IActionResult LogOut()
        {
            this.session.Clear();

            return RedirectToAction("Login", "HomePage");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
