using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELTPDomainModel;


namespace ELTPRepository
{
    public interface IRentalRepository
    {
        void StartMovieRental(Rentals r);
        void EditMovieRental(Rentals r);
        void EndMovieRental(int RenID);
    }
    public class RentalRepository : IRentalRepository
    {
        ELTPDbContext db;
        public RentalRepository() {
            db = new ELTPDbContext();
        }
        public void EditMovieRental(Rentals r)
        {
            Rentals ren = db.Rentals.Where(temp => temp.RentalID == r.RentalID).FirstOrDefault();
            if (ren != null)
            {
                ren.RentalDateAndTime = r.RentalDateAndTime;
                ren.RentalDuration = r.RentalDuration;
                db.SaveChanges();
            }
            
        }

        public void EndMovieRental(int renID)
        {
            Rentals ren = db.Rentals.Where(temp => temp.RentalID == renID).FirstOrDefault();
            if (ren != null)
            {
                db.Rentals.Remove(ren);
                db.SaveChanges();
            }
        }

        public void StartMovieRental(Rentals r)
        {
            db.Rentals.Add(r);
            db.SaveChanges();
        }
    }
}