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
        DevCodeContext _db;
        public ReferenceDataDao(DevCodeContext db)
        {
            _db = db;
        }


        public ReferenceData getAll()
        {
            var model = new ReferenceData();

            model.transTypes = (from d in _db.TransType
                                    //orderby d.IsActive, d.LocationDesc
                                select new LookupItem()
                                {
                                    id = d.TransTypeId,
                                    text = d.Description
                                }).ToArray();

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
