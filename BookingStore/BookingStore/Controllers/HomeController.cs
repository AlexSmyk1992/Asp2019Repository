using BookingStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {

            return View(db.Books.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if(b == null)
            {
                return HttpNotFound();
                
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Unsafe->
        //public ActionResult Delete(int id)
        //{
        //    Book b = db.Books.Find(id);
        //    if (b != null)
        //    {
        //        db.Books.Remove(b);
        //        db.SaveChanges();
        //    }

        //    //Book b = new Book { Id = id };
        //    //db.Entry(b).State = EntityState.Deleted;
        //    //db.SaveChanges();
        //    //return RedirectToAction("Index");
        //}

        public ActionResult GetBook(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
                return HttpNotFound();
            return View(b);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            return View(new Purchase { BookId = id, Person = "Hello" });
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Thanks," + purchase.Person + ", for purchase";
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}