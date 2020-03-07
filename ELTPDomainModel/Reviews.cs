using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELTPDomainModel
{
    public class Reviews
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewID { get; set; }

        public string ReviewText { get; set; }

        public DateTime ReviewDateAndTime { get; set; }

        public int UserID { get; set; }

        public int MovieID { get; set; }

        public int RatingsCount { get; set; }


        [ForeignKey("UserID")]
        public virtual Users User { get; set; }

    }
}