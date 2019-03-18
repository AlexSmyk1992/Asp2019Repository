using ArrayMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrayMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAuthor(Author author)
        {
            return View();
        }

        //public ActionResult Edit()
        //{
        //    List<Book> books = new List<Book>();
        //    books.Add(new Book { Name = "Война и мир", Author = "Лев Толстой", Price = 220 });
        //    books.Add(new Book { Name = "Отцы и дети", Author = "Иван Тургенев", Price = 180 });
        //    books.Add(new Book { Name = "Чайка", Author = "Антон Чехов", Price = 150 });
        //    return View(books);
        //}
        //[HttpPost]
        //public string Edit(List<Book> books)
        //{
        //    return books.Count.ToString();
        //}

        public ActionResult Array()
        {
            return View();
        }

        [HttpPost]
        public string  Array(List<string> names)
        {
            string fin = "";
            for (int i = 0; i < names.Count; i++)
            {
                fin += names[i] + "; ";
            }
            return fin;
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