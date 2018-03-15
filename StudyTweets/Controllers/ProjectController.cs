using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTweets.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {

            int userid = Convert.ToInt32(Session["userid"]);
            tabledbEntities entities = new tabledbEntities();
            List<ProjectWithFrontEndBackEnd> ProjectObjList = new List<ProjectWithFrontEndBackEnd>();

            var projectlst = entities.Projects
                .Join(entities.frontends, p => p.FrontendId, f => f.frontendid,
                 (p, f) => new {p.Name,
                     p.Description,p.Projectfile, f.frontendname,p.ProjectID,p})
                 .Join(entities.backends, p => p.p.BackendId, b => b.backendid,
                 (p, b) => new {p,b.backendname }).Where(o => o.p.p.UserId == userid).ToList();


            foreach(var proj in projectlst)
            {
                ProjectWithFrontEndBackEnd prj = new ProjectWithFrontEndBackEnd();
                prj.ProjectName = proj.p.Name;
                prj.ProjectId = proj.p.ProjectID;
                prj.ProjectDescription = proj.p.Description;
                prj.ProjectFile = proj.p.Projectfile;
                prj.FrontEndName = proj.p.frontendname;
                prj.BackEndName = proj.backendname;

                ProjectObjList.Add(prj);
            }

            return View(ProjectObjList);
        }

        public ActionResult Create()
        {
            tabledbEntities entities = new tabledbEntities();
            //List<SelectListItem> frontend =  
            ViewBag.FrontEnd = entities.frontends.ToList();
            ViewBag.BackEnd = entities.backends.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Project project, HttpPostedFileBase projectFile)
        {
            tabledbEntities entities = new tabledbEntities();
            if (projectFile != null)
            {
                string file = Guid.NewGuid().ToString().Substring(0, 6) + projectFile.FileName;
                projectFile.SaveAs(Server.MapPath("~/UploadedImages/") + file);
                project.Projectfile = file;
            }

            project.UserId = Convert.ToInt32(Session["userid"]);

            entities.Entry(project).State = System.Data.Entity.EntityState.Added;
            entities.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}