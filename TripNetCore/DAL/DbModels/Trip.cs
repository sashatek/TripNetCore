using System;
using System.Collections.Generic;

namespace TripNetCore.DAL.DbModels
{
    public partial class Trip
    {
        public int TripId { get; set; }
        public DateTime TripDate { get; set; }
        public int AirportId { get; set; }
        public int TransTypeId { get; set; }
        public string GroupName { get; set; }
        public int GroupSize { get; set; }
        public bool Active { get; set; }
        public string Note { get; set; }

        public virtual Airport Airport { get; set; }
        public virtual TransType TransType { get; set; }
    }
}
