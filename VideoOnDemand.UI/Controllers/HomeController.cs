using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VideoOnDemand.UI.Models;
using Microsoft.AspNetCore.Identity;
using VideoOnDemand.Data.Data.Entities;
using VideoOnDemand.Data.Repositories;

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
            var rep = new MockReadRepository();
            var courses = rep.GetCourses(
                "3fcd8c17-0a83-4c70-8b1c-9b2d4131a92f");
            var course = rep.GetCourse("3fcd8c17-0a83-4c70-8b1c-9b2d4131a92f", 1);
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
