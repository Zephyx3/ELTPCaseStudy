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
    public class EditMovieViewModel
    {
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public DateTime MovieDateAndTime { get; set; }

    }
}