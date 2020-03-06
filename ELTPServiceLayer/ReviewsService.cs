using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELTPDomainModel;
using ELTPRepository;
using ELTPServiceLayer;
using ELTPViewModel;
using AutoMapper;

namespace ELTPServiceLayer
{
    public interface IReviewsService
    {
        void InsertReview(NewReviewViewModel rvm);
        void UpdateReview(EditReviewViewModel rvm);
        void UpdateReviewVotesCount(int rid, int uid, int value);
        void DeleteReview(int rid);
        List<ReviewViewModel> GetReviewsByMovieID(int mid);
        ReviewViewModel GetReviewByReviewID(int ReviewID);

    }
    public class ReviewsService : IReviewsService
    {
        IReviewsRepository revr;
        public ReviewsService()
        {
            revr = new ReviewsRepository();
        }
        public void DeleteReview(int rid)
        {
            revr.DeleteReview(rid);
        }

        public ReviewViewModel GetReviewByReviewID(int ReviewID)
        {
            Reviews rev = revr.GetReviewsByReviewID(ReviewID).FirstOrDefault();
            ReviewViewModel rvm = null;
            if (rev != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Reviews, NewReviewViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                rvm = mapper.Map<Reviews, ReviewViewModel>(rev);
            }
            return rvm;
        }

        public List<ReviewViewModel> GetReviewsByMovieID(int mid)
        {
            List<Reviews> rev = revr.GetReviewsByReviewID(mid);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Reviews, ReviewViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<ReviewViewModel> rvm = mapper.Map<List<Reviews>, List<ReviewViewModel>>(rev);
            return rvm;
        }

        public void InsertReview(NewReviewViewModel rvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewReviewViewModel, Reviews>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Reviews rev = mapper.Map<NewReviewViewModel, Reviews>(rvm);
            revr.InsertReview(rev);
        }

        public void UpdateReview(EditReviewViewModel rvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditReviewViewModel, Reviews>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Reviews rev = mapper.Map<EditReviewViewModel, Reviews>(rvm);
            revr.UpdateReview(rev);
        }

        public void UpdateReviewVotesCount(int rid, int uid, int value)
        {
            revr.UpdateReviewVotesCount(rid, uid, value);
        }
    }
}