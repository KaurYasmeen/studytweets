using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class DashboardController : Controller
    {

       [HttpGet]
        public ActionResult Index()
        {
            tabledbEntities entities = new tabledbEntities();
            var userList = entities.Users.ToList();
            ViewBag.TotalUsers = entities.Users.Count();
            return View(userList);
        }
    }
}