using SharedTrip.Services.Trips;
using SharedTrip.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SharedTrip
{
    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ITripsService, TripsService>();
        }
    }
}
