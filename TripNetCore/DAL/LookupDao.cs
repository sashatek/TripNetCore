using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripNetCore.DAL.DbModels;
using TripNetCore.Models;

namespace TripNetCore.DAL
{
    public class LookupDao
    {
        DevCodeContext _db;
        public LookupDao(DevCodeContext db)
        {
            _db = db;
        }

        public LookupItem[] airportsByIata(string term)
        {
            var q = _db.Airport
                 .Where(c => c.IataIdent.StartsWith(term))
                 .OrderBy(c => c.IataIdent)
                 .Take(15)
                 .Select(c => new LookupItem()
                 {
                     id = (int)c.AirportId,
                     text = c.IataIdent,
                     text2 = c.Name.Trim()
                 })
                 .ToArray();


            return q;
        }
    }
}
