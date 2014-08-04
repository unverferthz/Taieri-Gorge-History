using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaeiriGorgeHistoric.Models;

namespace TaeiriGorgeHistoric.Controllers
{
    public class AddTripController : Controller
    {
        private TripDBContext tripDBContext = new TripDBContext();


        //Default view
        [HttpGet]
        public ActionResult AddTrip()
        {
            return View();
        }

        //On submit
        [HttpPost]
        public ActionResult AddTrip(Trip newTrip)
        {
            //Add new trip into database
            tripDBContext.Trips.Add(newTrip);

            //Save and go to screen comfirming it was added
            tripDBContext.SaveChanges();
            return View("SuccessfullyAddedTrip");
        }

    }
}
