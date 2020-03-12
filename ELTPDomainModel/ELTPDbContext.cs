using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ELTPDomainModel
{
    public class ELTPDbContext:DbContext
    {
        //public ELTPDbContext() : base("ELTPCaseStudy")
        //{
        //}
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Rentals> Rentals { get; set; }

        public DbSet<Users> Users{ get; set; }
    }
}