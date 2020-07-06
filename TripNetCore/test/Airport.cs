using System;
using System.Collections.Generic;

namespace TripNetCore.test
{
    public partial class Airport
    {
        public Airport()
        {
            Trip = new HashSet<Trip>();
        }

        public int AirportId { get; set; }
        public string IataIdent { get; set; }
        public string Ident { get; set; }
        public string IcaoCode { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }

        public virtual ICollection<Trip> Trip { get; set; }
    }
}
