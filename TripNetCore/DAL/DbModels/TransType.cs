using System;
using System.Collections.Generic;

namespace TripNetCore.DAL.DbModels
{
    public partial class TransType
    {
        public TransType()
        {
            Trip = new HashSet<Trip>();
        }

        public int TransTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Trip> Trip { get; set; }
    }
}
