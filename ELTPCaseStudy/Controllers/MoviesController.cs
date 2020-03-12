using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELTPServiceLayer;
using ELTPViewModel;
using ELTPDomainModel;
using ELTPCaseStudy.CustomFilter;

namespace ELTPCaseStudy.Controllers
{
    public class MoviesController : Controller
    {
        IMoviesService ms;
        private ELTPDbContext db = new ELTPDbContext();
        public MoviesController(IMoviesService ms)
        {
            this.ms = ms;
        }

        // GET: Movies
        public ActionResult Movies()
        {
            List<MovieViewModel> movies = this.ms.GetMovies().Take(10).ToList();
            return View("Movies", movies);
        }

        public ActionResult AddMovie()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilterAttr]
        public ActionResult AddMovie(NewMovieViewModel nmvm)
        {
                this.ms.InsertMovie(nmvm);
                return RedirectToAction("Index"); //returns to Movie list Page
        }

        public ActionResult EditMovies(EditMovieViewModel emvm)
        {
            if (ModelState.IsValid)
            {
                emvm.MovieID = Convert.ToInt32(Session["CurrentUserID"]);
                this.ms.UpdateMovieDetails(emvm);
                return RedirectToAction("Movies", new { id = emvm.MovieID });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return RedirectToAction("Movies", new { id = emvm.MovieID });
            }
        }

        public ActionResult DeleteMovie(int id)
        {
            ms.DeleteMovie(id);
            return RedirectToAction("MoviesList");
        }
    }
}