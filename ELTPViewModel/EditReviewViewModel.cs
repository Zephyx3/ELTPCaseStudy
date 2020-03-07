using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELTPViewModel
{
    public class EditReviewViewModel
    {
        [Required]
        public int ReviewID { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Required]
        public DateTime ReviewDateAndTime { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int MovieID { get; set; }
        [Required]
        public int RatingsCount { get; set; }
        public virtual MovieViewModel Movie { get; set; }
    }
}