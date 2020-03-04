using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELTPDomainModel
{
    public class Movies
    {
        [Key]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieReleased { get; set; }
        public int MovieReleaseDate { get; set; }
        public int MovieGenre { get; set; }
        public int MovieDescription { get; set; }
    }
}