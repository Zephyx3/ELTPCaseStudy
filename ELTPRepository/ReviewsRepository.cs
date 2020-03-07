using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELTPDomainModel;

namespace ELTPRepository
{
    public interface IReviewsRepository
    {
        void InsertReview(Reviews r);
        void UpdateReview(Reviews r);
        void UpdateReviewVotesCount(int rid, int uid, int value);
        void DeleteReview(int rid);
        List<Reviews> GetReviewsByMovieID(int rid);
        List<Reviews> GetReviewsByReviewID(int rid);

    }
    public class ReviewsRepository : IReviewsRepository
    {
        ELTPDbContext db;
        IMoviesRepository mr;
        public ReviewsRepository()
        {
            db = new ELTPDbContext();
            mr = new MoviesRepository();
        }

        public void DeleteReview(int rid)
        {
            Reviews rev = db.Reviews.Where(temp => temp.ReviewID == rid).FirstOrDefault();
            if (rev != null)
            {
                db.Reviews.Remove(rev);
                db.SaveChanges();
                mr.UpdateMovieReviewsCount(rev.ReviewID, -1);
            }
        }

        public List<Reviews> GetReviewsByMovieID(int rid)
        {
            List<Reviews> rev = db.Reviews.Where(temp => temp.ReviewID == rid).OrderByDescending(temp => temp.ReviewDateAndTime).ToList();
            return rev;
        }

        public List<Reviews> GetReviewsByReviewID(int rid)
        {
            List<Reviews> rev = db.Reviews.Where(temp => temp.ReviewID == rid).ToList();
            return rev;
        }

        public void InsertReview(Reviews r)
        {
            db.Reviews.Add(r);
            db.SaveChanges();
            mr.UpdateMovieReviewsCount(r.MovieID, 1);
        }

        public void UpdateReview(Reviews r)
        {
            Reviews rev = db.Reviews.Where(temp => temp.ReviewID == r.ReviewID).FirstOrDefault();
            if (rev != null)
            {
                rev.ReviewText = r.ReviewText;
                db.SaveChanges();
            }
        }

        public void UpdateReviewVotesCount(int rid, int uid, int value)
        {
            Reviews rev = db.Reviews.Where(temp => temp.ReviewID == rid).FirstOrDefault();
            if (rev != null)
            {
                rev.RatingsCount += value;
                db.SaveChanges();
                mr.UpdateMoviesRatingsCount(rev.ReviewID, value);
            }
        }
    }
}