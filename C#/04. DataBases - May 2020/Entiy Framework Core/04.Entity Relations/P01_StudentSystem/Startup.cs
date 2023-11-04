using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using StudentSystemContext context = new StudentSystemContext();

            context.Database.EnsureCreated();
        }
    }
}
