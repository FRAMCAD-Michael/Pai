using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pai.Models;

namespace Pai.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Project()
        {
            List<Project> projectList = new List<Project>();
            projectList.Add(new Project() { Id=321,ProjectName = "Dream bicycle", ProjectOwner = "Michael Lu", ProjectStatus = "Pending", CreatedOn = DateTime.Now.AddDays(-32) });
            projectList.Add(new Project() { Id =322, ProjectName = "Auto feeder", ProjectOwner = "Steven Smith", ProjectStatus = "Created", CreatedOn = DateTime.Now.AddDays(-7) });
            projectList.Add(new Project() { Id =323, ProjectName = "Multifunction chair", ProjectOwner = "Dick Smith Ltd", ProjectStatus = "In Process", CreatedOn = DateTime.Now.AddDays(-100) });
            return View(projectList);
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult SurveyInfo(string id)
        {
            var model = new {name="Michael", age=54 };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}