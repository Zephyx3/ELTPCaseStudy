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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieID { get; set; }
        public int UserID { get; set; }

        public string MovieName { get; set; }

        public string MovieReleased { get; set; }

        public DateTime MovieReleaseDate { get; set; }

        public string MovieGenre { get; set; }

        public string MovieDescription { get; set; }

        public int ReviewsCount { get; set; }

        public int RatingsCount { get; set; }

        public int ViewsCount { get; set; }


        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }

        public virtual List<Reviews> Reviews { get; set; }
    }
}