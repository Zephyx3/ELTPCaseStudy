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
        public ActionResult Index()
        {
            //this.ms.GetMoviesByMovieID(mid, 0);
            //int uid = Convert.ToInt32(Session["CurrentUserID"]);
            //MovieViewModel mvm = this.ms.GetMoviesByMovieID(mid, uid);
            //return View(mvm);

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
            nmvm.MovieID = Convert.ToInt32(Session["CurrentUserID"]);
            nmvm.MovieReleaseDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                this.ms.InsertMovie(nmvm);
                return RedirectToAction("Movies", "AddMovie", new { id = nmvm.MovieID });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                //MovieViewModel mvm = this.ms.GetMoviesByMovieID(nmvm.MovieID, nmvm.UserID);
                List<MovieViewModel> movies = this.ms.GetMovies().Take(10).ToList();
                return View("AddMovie", movies);
            }

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

        public ActionResult DeleteMovie(int mid)
        {
            Movies movies = db.Movies.Find(mid);
            if(movies == null){
                return View("NotFound");
            }
            db.Movies.Remove(movies);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}