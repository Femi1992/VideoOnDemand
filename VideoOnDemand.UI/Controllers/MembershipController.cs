using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoOnDemand.Data.Data.Entities;
using VideoOnDemand.Data.Repositories;
using VideoOnDemand.UI.Models.DTOModels;
using VideoOnDemand.UI.Models.MembershipViewModels;

namespace VideoOnDemand.UI.Controllers
{
    public class MembershipController : Controller
    {
        private string _userId;
        private IReadRepository _db;
        private readonly IMapper _mapper;
        public MembershipController(IHttpContextAccessor httpContextAccessor, 
            UserManager<User> userManager,
            IMapper mapper, IReadRepository db)
        {
            //get logged in user's UserID
            var user = httpContextAccessor.HttpContext.User;
            _userId = userManager.GetUserId(user);
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var courseDtoObjects = _mapper.Map<List<CourseDTO>>(_db.GetCourses(_userId));

            var dashboardModel = new DashboardViewModel();
            dashboardModel.Courses = new List<List<CourseDTO>>();

            var noOfRows = courseDtoObjects.Count <= 3 ? 1 : courseDtoObjects.Count / 3;
            for (var i= 0; i < noOfRows; i++)
            {
                dashboardModel.Courses.Add(courseDtoObjects.Take(3).ToList());
            }
            return View(dashboardModel);
        }

        [HttpGet]
        public IActionResult Course(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Video(int id)
        {
            return View();
        }
    }
}