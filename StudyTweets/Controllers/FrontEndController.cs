using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class FrontEndController : Controller
    {
        // GET: FrontEnd
        public ActionResult Index()
        {
            tabledbEntities entities = new tabledbEntities();
            var frontendResult = entities.frontends.ToList();
            return View(frontendResult);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(frontend frontendObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.frontends.Add(frontendObj);
            entities.SaveChanges();
            return RedirectToAction("index");

        }
       [HttpGet]
       public ActionResult Edit( int id)
        {
            tabledbEntities entities = new tabledbEntities();
            frontend frontendObj = entities.frontends.First(x => x.frontendid == id);
            return View(frontendObj);
        }
        [HttpPost]
        public ActionResult Edit(frontend frontendObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(frontendObj).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            frontend frontendObj = entities.frontends.First(x => x.frontendid == id);
            return View(frontendObj);
        }
        [HttpPost]
        public ActionResult delete(frontend frontendObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(frontendObj).State = System.Data.Entity.EntityState.Deleted;
            entities.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            frontend frontendObj = entities.frontends.First(x => x.frontendid == id);
            return View(frontendObj);
        }
      

        }
        
        }

    
    
