using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using ELTPDomainModel;
using ELTPRepository;
using ELTPViewModel;


namespace ELTPServiceLayer
{
    public interface IMoviesService
    {
        void InsertMovie(NewMovieViewModel mvm);
        void UpdateMovieDetails(EditMovieViewModel mvm);
        void UpdateMovieReviewsCount(int mid, int value);
        void UpdateMovieRatingsCount(int mid, int value);
        void UpdateMovieViewCount(int mid, int value);
        void DeleteMovie(int mid);

        List<MovieViewModel> GetMovies();
        MovieViewModel GetMoviesByMovieID(int mid, int uid);
    }
    public class MoviesService : IMoviesService
    {
        readonly IMoviesRepository mr;

        public MoviesService()
        {
            mr = new MoviesRepository();
        }
        public void DeleteMovie(int mid)
        {
            mr.DeleteMovie(mid);
        }

        public List<MovieViewModel> GetMovies()
        {
            List<Movies> m = mr.GetMovies();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Movies, MovieViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();

            List<MovieViewModel> mvm = mapper.Map<List<Movies>, List<MovieViewModel>>(m);
            return mvm;
        }

        public MovieViewModel GetMoviesByMovieID(int mid, int uid)
        {
            Movies m = mr.GetMoviesByMovieID(mid).FirstOrDefault();
            MovieViewModel mvm = null;
            if(m != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Movies, MovieViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();

                mvm = mapper.Map<Movies, MovieViewModel>(m);
                foreach(var item in mvm.Reviews)
                {
                    item.CurrentUserRatingType = 0;
                    RatingsViewModel vote = item.Ratings.Where(temp => temp.UserID == uid).FirstOrDefault();
                    if (vote != null)
                    {
                        item.CurrentUserRatingType = vote.RatingValue;
                    }
                }  
            }
            return mvm;
        }

        public void InsertMovie(NewMovieViewModel mvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewMovieViewModel,Movies>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Movies m = mapper.Map<NewMovieViewModel, Movies>(mvm);
            mr.InsertMovie(m);
        }

        public void UpdateMovieDetails(EditMovieViewModel mvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditMovieViewModel, Movies>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Movies m = mapper.Map<EditMovieViewModel, Movies>(mvm);
            mr.UpdateMovieDetails(m);
        }

        public void UpdateMovieRatingsCount(int mid, int value)
        {
            mr.UpdateMoviesRatingsCount(mid, value);
        }

        public void UpdateMovieReviewsCount(int mid, int value)
        {
            mr.UpdateMovieReviewsCount(mid, value);
        }

        public void UpdateMovieViewCount(int mid, int value)
        {
            mr.UpdateMoviesViewsCount(mid, value);
        }
    }
}