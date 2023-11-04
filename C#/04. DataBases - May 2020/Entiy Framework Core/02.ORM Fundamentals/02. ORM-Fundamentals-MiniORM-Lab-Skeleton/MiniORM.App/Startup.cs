using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

namespace MiniORM.App
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniDbContext(Configuration.ConnectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Hrisi",
                LastName = "Nikolova",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();

            employee.FirstName = "Hristina";

            context.SaveChanges();

            Console.WriteLine($"FirstName:{employee.FirstName}");
            Console.WriteLine($"LastName:{employee.LastName}");
        }
    }
}
