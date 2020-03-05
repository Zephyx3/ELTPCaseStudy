using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELTPDomainModel
{
    public class Rentals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalID { get; set; }
        public DateTime RentalDate { get; set; }

        [ForeignKey("UserID")]
        public virtual Users User { get; set; }

        [ForeignKey("MovieID")]
        public virtual List<Movies> Movie { get; set; }
    }
}