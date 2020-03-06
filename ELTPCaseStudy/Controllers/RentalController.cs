using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELTPCaseStudy.Controllers
{
    public class RentalController : Controller
    {
        public RentalController()
        {

        }
        // GET: Rental
        public ActionResult RentMovie()
        {
            return View();
        }
        public ActionResult UpdateMovie()
        {
            return View();
        }

        public ActionResult ReturnMovie()
        {
            return View();
        }


    }
}