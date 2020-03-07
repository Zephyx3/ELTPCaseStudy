using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ELTPViewModel
{
    public class MovieViewModel
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieReleased { get; set; }
        public DateTime MovieReleaseDate { get; set; }
        public string MovieGenre { get; set; }
        public string MovieDescription { get; set; }

        public UserViewModel User { get; set; }
        public virtual List<ReviewViewModel> Reviews { get; set; }

    }
}