using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ELTPViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\[a-zA-Z][2,6])")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]$")]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

    }
}