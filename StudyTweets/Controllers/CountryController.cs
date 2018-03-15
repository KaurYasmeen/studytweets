using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            tabledbEntities entities = new tabledbEntities();
            var countryResult = entities.countries.ToList();
            return View(countryResult);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(country countryObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.countries.Add(countryObj);
            entities.SaveChanges();
            return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult edit(int id )
        {
            tabledbEntities entities = new tabledbEntities();
            country countryObj = entities.countries.First(x => x.countryid == id);
            return View(countryObj);
        }
        [HttpPost]
        public ActionResult edit(country countryObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(countryObj).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult delete(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            country countryObj = entities.countries.First(x => x.countryid == id);
            return View(countryObj);
        }

        [HttpPost]
        public ActionResult delete(country countryObj)
        {
            tabledbEntities entities = new tabledbEntities();
            entities.Entry(countryObj).State = System.Data.Entity.EntityState.Deleted;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            tabledbEntities entities = new tabledbEntities();
            country countryObj = entities.countries.First(x => x.countryid == id);
            return View(countryObj);
        }

        }
    }
          