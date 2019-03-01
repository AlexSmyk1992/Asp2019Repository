using NavigationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace NavigationApp.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext db = new SoccerContext();
        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Team);
            return View(players.ToList());
        }

        [HttpPost]
        public ActionResult Create()
        {
            SelectList teams = new SelectList(db.Teams, "Id", "Name");
            ViewBag.Teams = teams;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return RedirectToAction("Index");
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