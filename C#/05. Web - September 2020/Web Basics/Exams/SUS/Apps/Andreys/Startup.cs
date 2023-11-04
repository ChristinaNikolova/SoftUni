using Andreys.Data;
using Andreys.Services.Products;
using Andreys.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace Andreys
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            var db = new AndreysDbContext();
            db.Database.EnsureCreated();
        }
    }
}
