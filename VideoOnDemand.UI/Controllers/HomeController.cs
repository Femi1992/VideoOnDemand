﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VideoOnDemand.UI.Models;
using Microsoft.AspNetCore.Identity;
using VideoOnDemand.Data.Data.Entities;

namespace VideoOnDemand.UI.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<User> _signInManager;

        public HomeController(SignInManager<User> signInMgr)
        {
            _signInManager = signInMgr;
        }

        public IActionResult Index()
        {
            //check if user is logged in
            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Login", "Account");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
