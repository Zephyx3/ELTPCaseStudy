using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace ELTPViewModel
{
    public class RatingsViewModel
    {
        public int RatingID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int RatingValue { get; set; }
    }
}