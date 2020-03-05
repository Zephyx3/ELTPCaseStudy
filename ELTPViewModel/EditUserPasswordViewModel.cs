using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELTPViewModel
{
    public class EditUserPasswordViewModel
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\[a-zA-Z][2,6])")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
