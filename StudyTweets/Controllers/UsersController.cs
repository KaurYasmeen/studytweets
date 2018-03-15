using StudyTweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class UsersController : Controller
    {

        //GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(User user)
        {
            tabledbEntities entites = new StudyTweets.tabledbEntities();
            var result = entites.Users.Where(x => x.Email == user.Email && x.Paswword == user.Paswword).FirstOrDefault();

            if (result != null)
            {
                if(result.IsApproved == 1) {
                    Session["userid"] = result.UsersID;
                return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Please Verify Account From Registered Email";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Wrong Username and Password";
            }

            return View();
        }

        [HttpGet]
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(User user, HttpPostedFileBase userImage)
        {

            if (userImage != null)
            {
                string image = Guid.NewGuid().ToString().Substring(0, 6) + userImage.FileName;
                userImage.SaveAs(Server.MapPath("~/UploadedImages/") + image);
                user.Image = image;
            }

            tabledbEntities entites = new StudyTweets.tabledbEntities();
            entites.Users.Add(user);
            entites.SaveChanges();
            EmailMessaging.SendEmail(user.Email);
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult Edit(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            User userObj = entities.Users.Where(x => x.UsersID == id).FirstOrDefault();
            return View(userObj);
        }
        [HttpPost]
        public ActionResult Edit( User userObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(userObj).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            User userObj = entities.Users.First(x => x.UsersID == id);
            return View(userObj);
        }

    }
}