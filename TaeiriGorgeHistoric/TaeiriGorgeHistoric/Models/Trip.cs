using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaeiriGorgeHistoric.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public string driver { get; set; }
        public DateTime date { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime endTime { get; set; }
        public string destination { get; set; }
    }
}