using IRunes.Data;
using IRunes.Services.Albums;
using IRunes.Services.Tracks;
using IRunes.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace IRunes
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IAlbumsService, AlbumsService>();
            serviceCollection.Add<ITracksService, TracksService>();
        }

        public void Configure(List<Route> routeTable)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }
    }
}
