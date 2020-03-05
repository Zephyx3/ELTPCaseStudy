using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using ELTPDomainModel;
using ELTPRepository;
using ELTPViewModel;


namespace ELTPServiceLayer
{
    public interface IMoviesService
    {
        void InsertMovie(Movies m);
        void UpdateMovieDetails(Movies m);
        void UpdateMovieReviewsCount(int rid, int value);
        void DeleteMovie(int rid);

        List<Movies> GetMovies();
        List<Movies> GetMoviesByMovieID(int rid);
    }
    public class MoviesServiceLayer : IMoviesService
    {
        public void DeleteMovie(int rid)
        {
            throw new NotImplementedException();
        }

        public List<Movies> GetMovies()
        {
            throw new NotImplementedException();
        }

        public List<Movies> GetMoviesByMovieID(int rid)
        {
            throw new NotImplementedException();
        }

        public void InsertMovie(Movies m)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovieDetails(Movies m)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovieReviewsCount(int rid, int value)
        {
            throw new NotImplementedException();
        }
    }
}