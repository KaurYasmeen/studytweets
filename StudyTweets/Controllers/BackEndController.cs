using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class BackEndController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            tabledbEntities entities = new tabledbEntities();
            var backendResult = entities.backends.ToList();
            return View(backendResult);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(backend backendObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(backendObj).State = EntityState.Added;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            backend backendObj = entities.backends.First(x => x.backendid == id);
            return View(backendObj);
        }

        [HttpPost]
        public ActionResult Edit(backend backendObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(backendObj).State = EntityState.Modified;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            backend backendObj = entities.backends.First(x => x.backendid == id);
            return View(backendObj);
        }

        [HttpPost]
        public ActionResult Delete(backend backendObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(backendObj).State = EntityState.Deleted;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            backend backendObj = entities.backends.First(x => x.backendid == id);
            return View(backendObj);
        }

    }
}