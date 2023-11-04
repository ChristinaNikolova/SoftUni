using Microsoft.EntityFrameworkCore;
using Suls.Data;
using Suls.Services.Problems;
using Suls.Services.Submissions;
using Suls.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace Suls
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
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}
