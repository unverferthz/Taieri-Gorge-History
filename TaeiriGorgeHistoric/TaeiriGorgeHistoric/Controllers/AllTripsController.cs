using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaeiriGorgeHistoric.Models;

namespace TaeiriGorgeHistoric.Controllers
{
    public class AllTripsController : Controller
    {
        private TripDBContext tripDBContext = new TripDBContext();

        //Show all of the trips in the database
        public ActionResult ShowAll()
        {
            //Get all the trips and pass into view
            List<Trip> allTrips = getAllTrips();
            return View(allTrips);
        }

        //Gets all the trips out of the database
        public List<Trip> getAllTrips()
        {
            //Put trips into a list
            List<Trip> allTrips = tripDBContext.Trips.ToList();

            return allTrips;
        }

    }
}
