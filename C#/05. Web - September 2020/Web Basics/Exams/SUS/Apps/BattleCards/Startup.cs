using BattleCards.Data;
using BattleCards.Services.Cards;
using BattleCards.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace BattleCards
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }
    }
}
