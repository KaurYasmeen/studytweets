using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class TechnologyController : Controller
    {
        // GET: Technology
        public ActionResult Index()
        {
            tabledbEntities entities = new tabledbEntities();
            var technolgyResult = entities.technolgies.ToList();
            return View(technolgyResult);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(technolgy technolgyObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.technolgies.Add(technolgyObj);
            entities.SaveChanges();
            return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            technolgy technolgyObj = entities.technolgies.First(x => x.technologyid == id);
            return View(technolgyObj);
        }
        [HttpPost]
        public ActionResult Edit(technolgy technolgyObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(technolgyObj).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            technolgy technolgyObj = entities.technolgies.First(x => x.technologyid == id);
            return View(technolgyObj);
        }
        [HttpPost]
        public ActionResult delete(technolgy technolgyObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(technolgyObj).State = System.Data.Entity.EntityState.Deleted;
            entities.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            technolgy technolgyObj = entities.technolgies.First(x => x.technologyid == id);
            return View(technolgyObj);
        }
    }
    }