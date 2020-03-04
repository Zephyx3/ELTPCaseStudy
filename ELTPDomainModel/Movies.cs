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
        public DateTime MovieReleaseDate { get; set; }
        public string MovieGenre { get; set; }
        public string MovieDescription { get; set; }
    }
}