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
        readonly DevCodeContext _db;
        public TripDao(DevCodeContext db)
        {
            _db = db;
        }

        public async Task<TripModel[]> getTripsAsync()
        {
            var tripModels = _db.Trip
                .Include(t => t.Airport)
                .Include(t => t.TransType)
                .Select(e => new TripModel
                {
                    tripId = e.TripId,
                    tripDate = e.TripDate,
                    airportId = e.AirportId,
                    airportInfo = new LookupItem()
                    {
                        id = e.AirportId,
                        text = e.Airport.IataIdent,
                        text2 = e.Airport.AirportName
                    },
                    transTypeId = e.TransTypeId,
                    transTypeDesc = e.TransType.Description,
                    groupName = e.GroupName,
                    groupSize = e.GroupSize,
                    active = e.Active,
                    note = e.Note

                });
            return await tripModels.ToArrayAsync();
        }

        public async Task<TripModel> getTripAsync(int tripId)
        {
            var tripModel = _db.Trip
                .Include(t => t.Airport)
                .Include(t => t.TransType)
                .Where(t => t.TripId == tripId)
                .Select(e => new TripModel
                {
                    tripId = e.TripId,
                    tripDate = e.TripDate,
                    airportId = e.AirportId,
                    airportInfo = new LookupItem()
                    {
                        id = e.AirportId,
                        text = e.Airport.IataIdent,
                        text2 = e.Airport.AirportName
                    },
                    transTypeId = e.TransTypeId,
                    transTypeDesc = "",  // Add your text/desc field name like e.TransType.Description
                    groupName = e.GroupName,
                    groupSize = e.GroupSize,
                    active = e.Active,
                    note = e.Note

                })
                .SingleOrDefaultAsync();

            return await tripModel;
        }
        public async Task<TripModel> addTripAsync(TripModel model)
        {
            var trip = new Trip();
            updateFromModel(trip, model);
            _db.Trip.Add(trip);
            await _db.SaveChangesAsync();
            model.tripId = trip.TripId;
            return model;
        }
        public async Task<TripModel> saveTripAsync(TripModel model)
        {
            var trip = _db.Trip.Find(model.tripId);
            updateFromModel(trip, model);
            _db.Entry(trip).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<int> deleteTripAsync(int id)
        {
            var trip = _db.Trip.Find(id);
            if (trip == null)
            {
                return -1;
            }

            _db.Trip.Remove(trip);
            await _db.SaveChangesAsync();
            return 0;
        }

        public void updateFromModel(Trip trip, TripModel model)
        {
            if (trip != null)
            {
                trip.TripId = model.tripId;
                trip.TripDate = model.tripDate;
                trip.AirportId = model.airportId;
                trip.AirportId = model.airportInfo.id; // Select one
                trip.TransTypeId = model.transTypeId;
                trip.GroupName = model.groupName;
                trip.GroupSize = model.groupSize;
                trip.Active = model.active;
                trip.Note = model.note;

            }
        }
    }

}
