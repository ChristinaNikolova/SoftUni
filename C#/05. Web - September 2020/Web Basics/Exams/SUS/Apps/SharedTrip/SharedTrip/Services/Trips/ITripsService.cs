using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services.Trips
{
    public interface ITripsService
    {
        IEnumerable<AllTripsViewModel> GetAll();

        void AddTrip(string startPoint, string endPoint, string imagePath, int seats, string departureTime, string description);

        DetailsTripViewModel GetDetailsTrip(string tripId);

        bool AddUserToTrip(string tripId, string userId);
    }
}
