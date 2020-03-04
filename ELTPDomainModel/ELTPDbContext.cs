using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ELTPDomainModel
{
    public class ELTPDbContext:DbContext
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users{ get; set; }
    }
}