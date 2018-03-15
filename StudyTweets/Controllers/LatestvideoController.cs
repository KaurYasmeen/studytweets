using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class LatestvideoController : Controller
    {
        // GET: Latestvideo
        public ActionResult Index()
        {
            tabledbEntities entities = new tabledbEntities();
            var videoList = entities.videos.ToList();
          
            return View(videoList);
        }
       

        }
    }

