using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ELTPViewModel
{
    public class NewMovieViewModel
    {
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string MovieReleased { get; set; }

        [Required]
        public DateTime MovieReleaseDate { get; set; }

        [Required]
        public string MovieGenre { get; set; }

        [Required]
        public string MovieDescription { get; set; }

        [Required]
        public int ReviewsCount { get; set; }

        [Required]
        public int RatingsCount { get; set; }

        [Required]
        public int ViewsCount { get; set; }
    }
}