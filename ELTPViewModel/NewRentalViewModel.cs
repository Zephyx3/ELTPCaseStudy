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
    public class NewRentalViewModel
    {

        public int RentalID { get; set; }

        [Required]
        public DateTime RentalDateAndTime { get; set; }

        [Required]
        public DateTime RentalDuration { get; set; }

        public virtual UserViewModel User { get; set; }
        public virtual MovieViewModel Movie { get; set; }

    }
}