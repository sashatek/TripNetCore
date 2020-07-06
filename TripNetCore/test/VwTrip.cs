using System;
using System.Collections.Generic;

namespace TripNetCore.test
{
    public partial class VwTrip
    {
        public int TripId { get; set; }
        public DateTime TripDate { get; set; }
        public int AirportId { get; set; }
        public string IataIdent { get; set; }
        public string Name { get; set; }
        public int TransTypeId { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public int GroupSize { get; set; }
        public bool Active { get; set; }
        public string Note { get; set; }
    }
}
