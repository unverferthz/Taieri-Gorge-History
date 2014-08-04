using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TaeiriGorgeHistoric.Models
{
    public class TripDBContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<GPS_Point> GPS_Points { get; set; }
    }
}