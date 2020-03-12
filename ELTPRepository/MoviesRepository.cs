using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELTPDomainModel;

namespace ELTPRepository
{
    public interface IMoviesRepository
    {
        void InsertMovie(Movies m);
        void UpdateMovieDetails(Movies m);
        void UpdateMovieReviewsCount(int mid, int value);
        void UpdateMoviesRatingsCount(int mid, int value);
        void UpdateMoviesViewsCount(int mid, int value);
        void DeleteMovie(int mid);

        List<Movies> GetMovies();
        List<Movies> GetMoviesByMovieID(int MovieID);
    }
    public class MoviesRepository : IMoviesRepository
    {
        ELTPDbContext db;
        public MoviesRepository()
        {
            db = new ELTPDbContext();
        }

        public void DeleteMovie(int mid)
        {
            Movies mo = db.Movies.Where(temp => temp.MovieID == mid).First();
            if (mo != null)
            {
                db.Movies.Remove(mo);
                db.SaveChanges();
            }
        }

        public List<Movies> GetMovies()
        {
            //List<Movies> mo = db.Movies.OrderByDescending(temp => temp.MovieReleaseDate).ToList();
            List<Movies> mo = db.Movies.OrderByDescending(temp => temp.MovieName).ToList();
            return mo;
        }

        public List<Movies> GetMoviesByMovieID(int MovieID)
        {
            List<Movies> mo = db.Movies.OrderByDescending(temp => temp.MovieID == MovieID).ToList();
            return mo;
        }

        public void InsertMovie(Movies m)
        {
            db.Movies.Add(m);
            db.SaveChanges();
        }

        public void UpdateMovieDetails(Movies m)
        {
            Movies mo = db.Movies.Where(temp => temp.MovieID == m.MovieID).FirstOrDefault();
            if (mo != null)
            {
                mo.MovieName = m.MovieName;
                mo.MovieReleaseDate = m.MovieReleaseDate;
                mo.MovieGenre = m.MovieGenre;
                mo.MovieDescription = m.MovieDescription;
                db.SaveChanges();
            }
            
        }

        public void UpdateMovieReviewsCount(int rid, int value)
        {
            Movies mo = db.Movies.Where(temp => temp.MovieID == rid).FirstOrDefault();
            if (mo != null)
            {
                mo.ReviewsCount += value;
                db.SaveChanges();
            }
        }

        public void UpdateMoviesRatingsCount(int mid, int value)
        {
            Movies mo = db.Movies.Where(temp => temp.MovieID == mid).FirstOrDefault();
            if (mo != null)
            {
                mo.RatingsCount += value;
                db.SaveChanges();
            }
        }

        public void UpdateMoviesViewsCount(int mid, int value)
        {
            Movies mo = db.Movies.Where(temp => temp.MovieID == mid).FirstOrDefault();
            if(mo != null)
            {
                mo.ViewsCount += value;
                db.SaveChanges();
            }
        }
    }
}
