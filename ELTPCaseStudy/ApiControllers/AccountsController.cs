using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELTPServiceLayer;

namespace ELTPCaseStudy.ApiControllers
{
    public class AccountsController : Controller
    {
        readonly IUsersService us;
        
        public AccountsController(IUsersService us)
        {
            this.us = us;
        }
        public string Get(string Email)
        {
            if (this.us.GetUsersByEmail(Email) != null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }
    }
}