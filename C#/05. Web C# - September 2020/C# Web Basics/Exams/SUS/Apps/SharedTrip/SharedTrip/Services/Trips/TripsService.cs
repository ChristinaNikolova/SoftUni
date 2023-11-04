using Microsoft.VisualBasic;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services.Trips
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddTrip(string startPoint, string endPoint, string imagePath, int seats, string departureTime, string description)
        {
            var trip = new Trip()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                Description = description,
                Seats = seats,
                ImagePath = imagePath,
                DepartureTime = DateTime.ParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var isSuccess = true;

            var trip = this.db
                .Trips
                .FirstOrDefault(t => t.Id == tripId);

            if (trip.Seats == 0)
            {
                isSuccess = false;
                return isSuccess;
            }

            var isTripAlreadyAdded = this.db
                .UserTrips
                .Any(ut => ut.UserId == userId && ut.TripId == tripId);

            if (isTripAlreadyAdded)
            {
                isSuccess = false;
                return isSuccess;
            }

            var userTrip = new UserTrip()
            {
                UserId = userId,
                TripId = tripId,
            };

            trip.Seats -= 1;

            this.db.UserTrips.Add(userTrip);
            this.db.Trips.Update(trip);
            this.db.SaveChanges();

            return isSuccess;
        }

        public IEnumerable<AllTripsViewModel> GetAll()
        {
            var trips = this.db
                .Trips
                .Select(t => new AllTripsViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                })
                .ToList();

            return trips;
        }

        public DetailsTripViewModel GetDetailsTrip(string tripId)
        {
            var trip = this.db
                .Trips
                .Where(t => t.Id == tripId)
                .Select(t => new DetailsTripViewModel()
                {
                    Id = t.Id,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Description = t.Description,
                    ImagePath = t.ImagePath,
                    Seats = t.Seats,
                })
                .FirstOrDefault();

            return trip;
        }
    }
}
