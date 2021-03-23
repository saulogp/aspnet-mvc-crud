using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmesLivros.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var list = this.CRUD().Select();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                this.CRUD().Insert(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            var book = this.CRUD().SelectById(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                this.CRUD().Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Details(int id)
        {
            var book = this.CRUD().SelectById(id);
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            var book = this.CRUD().SelectById(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var book = this.CRUD().Delete(id);
            return RedirectToAction("Index");
        }

        private IBookDB CRUD()
        {
            return new BookDB();
        }
    }
}