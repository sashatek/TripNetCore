using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TtipNetCore.Models
{
    public class AirportIdentity
    {
        public int airportId { get; set; }
        public string iataIdent { get; set; }
        public string ident { get; set; }
        public string icaoCode { get; set; }
        public string name { get; set; }
    }
}
