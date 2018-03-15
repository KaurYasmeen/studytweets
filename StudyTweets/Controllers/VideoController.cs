using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            int userid = Convert.ToInt32(Session["userid"]);
            tabledbEntities entities = new tabledbEntities();
            var videolist = entities.videos.Join
                (entities.technolgies, r => r.technologyid, p => p.technologyid, (r, p)
               => new VideoWithTechnology { video = r, technolgy = p }).Where(t => t.video.userid == userid);

            return View(videolist.ToList());
        }
        public ActionResult Create()
        {
            tabledbEntities entities = new tabledbEntities();

            ViewBag.Technology = entities.technolgies.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(video videoss, HttpPostedFileBase uploadfile)
        {
            tabledbEntities entities = new tabledbEntities();
            if (uploadfile != null)
            {
               string file = Guid.NewGuid().ToString().Substring(0, 6) + uploadfile.FileName;
                uploadfile.SaveAs(Server.MapPath("~/UploadedImages/") + file);
                videoss.uploadfile = file;
            }
            videoss.userid = Convert.ToInt32(Session["userid"]);

            entities.Entry(videoss).State = System.Data.Entity.EntityState.Added;
            entities.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}