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

        List<Reviews> GetReviewsByMovieID(int rid);
        List<Reviews> GetReviewsByReviewID(int rid);

    }
    public class ReviewsRepository : IReviewsRepository
    {
        public List<Reviews> GetReviewsByMovieID(int rid)
        {
            throw new NotImplementedException();
        }

        public List<Reviews> GetReviewsByReviewID(int rid)
        {
            throw new NotImplementedException();
        }

        public void InsertReview(Reviews r)
        {
            throw new NotImplementedException();
        }

        public void UpdateReview(Reviews r)
        {
            throw new NotImplementedException();
        }

        public void UpdateReviewVotesCount(int rid, int uid, int value)
        {
            throw new NotImplementedException();
        }
    }
}