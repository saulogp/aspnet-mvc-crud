using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmesLivros.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var list = this.CRUD().Select();
            return View(list);
        }

        #region CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //aceita apenas requisições do controlador
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.CRUD().Insert(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        #endregion

        #region EDIT
        public ActionResult Edit(int id)
        {
            var movie = this.CRUD().SelectById(id);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)//similar ao movie != null
            {
                this.CRUD().Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        #endregion
        
        #region Details
        public ActionResult Details(int id)
        {
            var movie = this.CRUD().SelectById(id);
            return View(movie);
        }
        #endregion
        
        #region Delete
        public ActionResult Delete(int id)
        {
            var movie = this.CRUD().SelectById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]//OO não permite métodos com a mesma assinatura e mesmo nome logo ActionName permite esse desvio
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var movie = this.CRUD().Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
        private IMovieDB CRUD()
        {
            return new MovieDB();
        }
    }
}