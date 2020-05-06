using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripNetCore.Models
{
    public class TripModel
    {
        public int tripId { get; set; }
        public DateTime tripDate { get; set; }
        public int airportId { get; set; }
        public LookupItem airportInfo { get; set; }
        public int transTypeId { get; set; }
        public string transTypeDesc { get; set; }
        public string groupName { get; set; }
        public int groupSize { get; set; }
        public bool active { get; set; }
        public string note { get; set; }
    }
}
