using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using FootballBettingContext context = new FootballBettingContext();

            context.Database.EnsureCreated();
        }
    }
}
