using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELTPViewModel
{
    public class EditUserDetailsViewModel
    {
        public int UserID { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\[a-zA-Z][2,6])")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]$")]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

    }
}