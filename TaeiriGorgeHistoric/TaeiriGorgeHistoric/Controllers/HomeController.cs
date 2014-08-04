using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaeiriGorgeHistoric.Models;
using System.Data.SqlClient;

namespace TaeiriGorgeHistoric.Controllers
{
    public class HomeController : Controller
    {
        private TripDBContext tripDBContext = new TripDBContext();


        //Default view
        public ActionResult Index()
        {
            //Set up drivers for drop down
            setUpDriverList();

            //Put the most recent trips into a list
            List<Trip> tripsToPassThrough = getMostRecentTrips();

            //Pass most recent trips into the view
            return View(tripsToPassThrough);
        }       


        //Gets all of the drivers out of the database
        //Need to make it so it doesn't repeat drivers
        public void setUpDriverList()
        {
            //List to hold drivers
            List<string> drivers = new List<string>();

            //All trips
            List<Trip> allTrips = tripDBContext.Trips.ToList();

            //Put all of the drivers from trip into the driver list
            foreach (Trip t in allTrips)
            {
                drivers.Add(t.driver);
            }


            //Variables for the drop down box
            List<SelectListItem> driversList = new List<SelectListItem>();
            SelectListItem newDriver = new SelectListItem();

            foreach (String s in drivers)
            {
                newDriver = new SelectListItem { Text = s, Value = s };
                driversList.Add(newDriver);
            }

            //Put driver list into viewbag for view to use
            ViewBag.driverList = driversList;
        }

        //Get the 5 most recent trips
        public List<Trip> getMostRecentTrips()
        {
            //All trips
            List<Trip> trips = tripDBContext.Trips.ToList();

            //Make list to hold most recent trips
            List<Trip> mostRecent = new List<Trip>();


            //Order trips by date
            IEnumerable<Trip> orderedByDateTrips = trips.OrderBy(t => t.date);

            //Take the 5 most recent trips
            int tripCount = 0;
            foreach (Trip t in orderedByDateTrips)
            {
                if (tripCount < 5)
                {
                    mostRecent.Add(t);
                    tripCount++;
                }
            }

            //Pass out list of trips
            return mostRecent;
        }
    }
}
