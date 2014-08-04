using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaeiriGorgeHistoric.Models
{
    public class TripAndGPS
    {
        public Trip currentTrip { get; set; }
        public List<GPS_Point> GPS_points { get; set; }
    }
}