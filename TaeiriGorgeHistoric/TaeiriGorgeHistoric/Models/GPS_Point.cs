using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaeiriGorgeHistoric.Models
{
    public class GPS_Point
    {
        public int GPS_PointID { get; set; }
        public virtual Trip trip { get; set; }
        public string GPSCoordinate { get; set; }
        public DateTime currentTime { get; set; }
        public int currentSpeed { get; set; }
    }
}