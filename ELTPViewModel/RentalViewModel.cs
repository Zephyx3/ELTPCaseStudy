using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ELTPViewModel
{
    public class RentalViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalID { get; set; }
        public DateTime RentalDateAndTime { get; set; }
        public DateTime RentalDuration { get; set; }


        public virtual UserViewModel User { get; set; }

        public virtual List<RentalViewModel> Rentals { get; set; }
    }
}