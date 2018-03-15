using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            tabledbEntities entites = new StudyTweets.tabledbEntities();
            var resultList = entites.Users.ToList();
            ViewBag.TotalUsers = resultList.Count();
            ViewBag.Approved = resultList.Where(x => x.IsApproved == 1).Count();
            ViewBag.NonApproved = resultList.Where(x => x.IsApproved == 0).Count();

            return View(resultList);
        }
    }
}
