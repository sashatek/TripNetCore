using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripNetCore.DAL.DbModels;
using TripNetCore.Models;

namespace TripNetCore.DAL
{
    public class TripDao
    {
        DevCodeContext _db;
        public TripDao(DevCodeContext db)
        {
            _db = db;
        }

        public TripModel[] getTrips()
        {
            var tripModels = _db.Trip
                .Include(t => t.Airport)
                .Include(t => t.TransType)
                .Select(t => new TripModel
                {
                    tripId = t.TripId,
                    tripDate = t.TripDate,
                    airport = new LookupItem
                    {
                        id = t.Airport.AirportId,
                        text = t.Airport.IataIdent,
                        text2 = t.Airport.Name
                    },
                    transTypeId = t.TransTypeId,
                    transTypeDesc = t.TransType.Description,
                    groupSize = t.GroupSize,
                    groupName = t.GroupName,
                    isActive = t.Active
                });
            return tripModels.ToArray();
        }

        public TripModel getTrip(int tripId)
        {
            var tripModel = _db.Trip
                .Include(t => t.Airport)
                .Include(t => t.TransType)
                .Where(t=>t.TripId == tripId)
                .Select(t => new TripModel
                {
                    tripId = t.TripId,
                    tripDate = t.TripDate,
                    airport = new LookupItem
                    {
                        id = t.Airport.AirportId,
                        text = t.Airport.IataIdent,
                        text2 = t.Airport.Name
                    },
                    transTypeId = t.TransTypeId,
                    transTypeDesc = t.TransType.Description,
                    groupSize = t.GroupSize,
                    groupName = t.GroupName,
                    isActive = t.Active,
                    note = t.Note
                })
                .SingleOrDefault();
            return tripModel;
        }
        public TripModel addTrip(TripModel model)
        {
            var trip = new Trip();
            updateFromModel(trip, model);
            _db.Trip.Add(trip);
            _db.SaveChanges();
            model.tripId = trip.TripId;
            return model;
        }
        public int saveTrip(TripModel model)
        {
            var trip = _db.Trip.Find(model.tripId);
            updateFromModel(trip, model);
            _db.Entry(trip).State = EntityState.Modified;
            return _db.SaveChanges();
        }
 

        public async Task<TripModel> addTripAsync(TripModel model)
        {
            var trip = new Trip();
            updateFromModel(trip, model);
            _db.Trip.Add(trip);
            await _db.SaveChangesAsync();
            model.tripId = trip.TripId;
            return model ;
        }

        public int deleteTrip(int id)
        {
            var trip = _db.Trip.Find(id);
            if (trip == null)
            {
                return -1;
            }

            _db.Trip.Remove(trip);
            _db.SaveChanges();
            return 0;
        }
 
        public void updateFromModel(Trip trip, TripModel model)
        {
            if (trip != null)
            {
                trip.TripId = model.tripId;
                trip.TripDate = model.tripDate;
                trip.AirportId = model.airport != null ? model.airport.id : 0;
                trip.TransTypeId = model.transTypeId;
                trip.GroupSize = model.groupSize;
                trip.GroupName = model.groupName;
                trip.Active = model.isActive;
                trip.Note = model.note;
            }
        }


    }
}
