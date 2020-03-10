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
    public interface IRentalService
    {
        void StartMovieRental(NewRentalViewModel rvm);
        void EditMovieRental(EditRentalViewModel rvm);
        void EndMovieRental(int RenID);
    }
    public class RentalService : IRentalService
    {
        IRentalRepository rr;

        public RentalService()
        {
            rr = new RentalRepository();
        } 
        public void EditMovieRental(EditRentalViewModel rvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditRentalViewModel, Rentals>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Rentals r = mapper.Map<EditRentalViewModel, Rentals>(rvm);
            rr.EditMovieRental(r);
        }

        public void EndMovieRental(int RenID)
        {
            rr.EndMovieRental(RenID);
        }

        public void StartMovieRental(NewRentalViewModel rvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewRentalViewModel, Rentals>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Rentals r = mapper.Map<NewRentalViewModel, Rentals>(rvm);
            rr.StartMovieRental(r);
        }
    }

}