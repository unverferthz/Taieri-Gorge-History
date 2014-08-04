using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaeiriGorgeHistoric.Models;

namespace TaeiriGorgeHistoric.Controllers
{
    public class TripDetailsController : Controller
    {
        private TripDBContext tripDBContext = new TripDBContext();

        //Display information about a trip
        public ActionResult TripDetails(int tripID)
        {
            List<Trip> allTrips = tripDBContext.Trips.ToList();
            List<GPS_Point> allGPSPoints = tripDBContext.GPS_Points.ToList();

            Trip matchedTrip = new Trip();

            foreach (Trip t in allTrips)
            {
                if (t.TripID == tripID)
                    matchedTrip = t;
            }

            List<GPS_Point> currentTripsGPSPoints = new List<GPS_Point>();

            foreach (GPS_Point g in allGPSPoints)
            {
                if (g.trip == matchedTrip)
                    currentTripsGPSPoints.Add(g);
            }

            TripAndGPS tripAndGPS = new TripAndGPS
            {
                currentTrip = matchedTrip,
                GPS_points = currentTripsGPSPoints
            };

            string[] allLatLangs = new string[currentTripsGPSPoints.Count];

            for (int i = 0; i < currentTripsGPSPoints.Count; i++)
            {
                allLatLangs[i] = getLatLang(currentTripsGPSPoints[i].GPSCoordinate);
            }


            ViewBag.allLatLangs = allLatLangs;

            //Return model of trip
            return View(tripAndGPS);
        }

        public string getLatLang(string gpsCoordinate)
        {
            int latMultiplier = 1;
            int longMultiplier = 1;

            if(gpsCoordinate.Contains("S"))
                latMultiplier = -1;

            if(gpsCoordinate.Contains("W"))
                longMultiplier = -1;

            string[] splitCoordinate = gpsCoordinate.Split(' ');

            double latDegrees = Convert.ToDouble(splitCoordinate[1]);
            double latMinutes = Convert.ToDouble(splitCoordinate[2]);
            double latSeconds = Convert.ToDouble(splitCoordinate[3]);

            double longDegrees = Convert.ToDouble(splitCoordinate[5]);
            double longMinutes = Convert.ToDouble(splitCoordinate[6]);
            double longSeconds = Convert.ToDouble(splitCoordinate[7]);

            double latitude = latDegrees + (latMinutes / 60) + (latSeconds / 3600);
            double longitude = longDegrees + (longMinutes / 60) + (longSeconds / 3600);

            latitude *= latMultiplier;
            longitude *= longMultiplier;

            string latLong = latitude.ToString() + "," + longitude.ToString();

            return latLong;
        }

    }
}
