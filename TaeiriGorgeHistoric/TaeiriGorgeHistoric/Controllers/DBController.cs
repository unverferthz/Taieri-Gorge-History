using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaeiriGorgeHistoric.Models;

namespace TaeiriGorgeHistoric.Controllers
{
    public class DBController : Controller
    {
        private TripDBContext tripDBContext = new TripDBContext();

        //Default method
        public ActionResult Index()
        {
            try
            {
                clearTables();
            }
            catch (Exception e)
            {
            }
            populateTables();
            return View();
        }

        //Add dummy data into database
        public void populateTables()
        {
            var trips = new List<Trip>
            {
                new Trip { driver="Frank", date=DateTime.Now, departureTime=DateTime.Now, endTime=DateTime.Now.AddHours(4), destination="Frankton"},
                new Trip { driver="Bob", date=DateTime.Now.AddDays(1), departureTime=DateTime.Now, endTime=DateTime.Now.AddHours(4), destination="Frankton"},
                new Trip { driver="Jim", date=DateTime.Now.AddDays(2), departureTime=DateTime.Now, endTime=DateTime.Now.AddHours(4), destination="Frankton"},
                new Trip { driver="Mary", date=DateTime.Now.AddDays(3), departureTime=DateTime.Now, endTime=DateTime.Now.AddHours(4), destination="Frankton"},
                new Trip { driver="John", date=DateTime.Now.AddDays(4), departureTime=DateTime.Now, endTime=DateTime.Now.AddHours(4), destination="Frankton"},
                new Trip { driver="Chris", date=DateTime.Now.AddDays(5), departureTime=DateTime.Now, endTime=DateTime.Now.AddHours(4), destination="Frankton"},
                new Trip { driver="Richard", date=DateTime.Now.AddDays(6), departureTime=DateTime.Now, endTime=DateTime.Now.AddHours(4), destination="Frankton"}
            };


            var GPS_points = new List<GPS_Point>
            {
                new GPS_Point { trip = trips[0], GPSCoordinate="S 45 51 47.680 E 170 23 5.496", currentTime=DateTime.Now, currentSpeed=50},
                new GPS_Point { trip = trips[0], GPSCoordinate="S 45 50 47.690 E 170 22 5.500", currentTime=DateTime.Now, currentSpeed=50},
                new GPS_Point { trip = trips[0], GPSCoordinate="S 45 49 47.700 E 170 21 5.510", currentTime=DateTime.Now, currentSpeed=50},
                new GPS_Point { trip = trips[0], GPSCoordinate="S 45 48 47.710 E 170 20 5.520", currentTime=DateTime.Now, currentSpeed=50},
                new GPS_Point { trip = trips[0], GPSCoordinate="S 45 47 47.720 E 170 19 5.530", currentTime=DateTime.Now, currentSpeed=50},
                new GPS_Point { trip = trips[0], GPSCoordinate="S 45 46 47.730 E 170 18 5.540", currentTime=DateTime.Now, currentSpeed=50},
                new GPS_Point { trip = trips[0], GPSCoordinate="S 45 45 47.740 E 170 17 5.550", currentTime=DateTime.Now, currentSpeed=50}
            };

            foreach (Trip t in trips)
                tripDBContext.Trips.Add(t);

            tripDBContext.SaveChanges();

            foreach (GPS_Point g in GPS_points)
                tripDBContext.GPS_Points.Add(g);

            tripDBContext.SaveChanges();
        }


        //Clear out existing records in database
        public void clearTables()
        {
            List<Trip> allTrips = tripDBContext.Trips.ToList();
            List<GPS_Point> allGPS_Points = tripDBContext.GPS_Points.ToList();

            foreach (Trip t in allTrips)
                tripDBContext.Trips.Remove(t);

            foreach (GPS_Point g in allGPS_Points)
                tripDBContext.GPS_Points.Remove(g);

            tripDBContext.SaveChanges();
        }

    }
}
