﻿using Microsoft.EntityFrameworkCore;
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
        readonly DevCodeContext _db;
        public LookupDao(DevCodeContext db)
        {
            _db = db;
        }

        public async Task<LookupItem[]> airportsByIataAsync(string term)
        {
            return await _db.Airport
                 .Where(c => c.IataIdent.StartsWith(term))
                 .OrderBy(c => c.IataIdent)
                 .Take(15)
                 .Select(c => new LookupItem()
                 {
                     id = (int)c.AirportId,
                     text = c.IataIdent,
                     text2 = c.AirportName.Trim()
                 })
                 .ToArrayAsync();
        }
    }
}
