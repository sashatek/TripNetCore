using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripNetCore.DAL.DbModels;
using TripNetCore.Models;

namespace TripCore.DAL
{
    public class ReferenceDataDao
    {
        readonly DevCodeContext _db;
        public ReferenceDataDao(DevCodeContext db)
        {
            _db = db;
        }


        public async Task<ReferenceData> getAllAsync()
        {
            var model = new ReferenceData();

            model.transTypes = await (from d in _db.TransType
                                    //orderby d.IsActive, d.LocationDesc
                                select new LookupItem()
                                {
                                    id = d.TransTypeId,
                                    text = d.Description
                                }).ToArrayAsync();

            // From enum
            //
            //model.controlTypes = (Enum.GetValues(typeof(YourEnumType)).Cast<YourEnumType>()
            //        .Select(c => new LookupItem()
            //        {
            //            id = (int)c,
            //            text = c.ToString()
            //        }))
            //        .ToArray();

            return model;
        }
    }
}
