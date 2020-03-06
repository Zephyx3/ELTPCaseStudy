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
    public class NewReviewViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewID { get; set; }
        public string ReviewName { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDateAndTime { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }

        [ForeignKey("UserID")]
        public virtual UserViewModel User { get; set; }

    }
}