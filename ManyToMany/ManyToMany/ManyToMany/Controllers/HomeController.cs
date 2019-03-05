using ManyToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManyToMany.Controllers
{
    public class HomeController : Controller
    {
        private StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
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
    }
}