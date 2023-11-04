using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Cinema.Data;
using Cinema.DataProcessor.ExportDto;

namespace Cinema.DataProcessor
{
    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                .Movies
                .Where(m => m.Rating >= rating
                    && m.Projections.Any(p => p.Tickets.Count() > 0))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Take(10)
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = m.Projections
                    .SelectMany(p => p.Tickets
                    .Select(t => new
                    {
                        t.Customer.FirstName,
                        t.Customer.LastName,
                        Balance = t.Customer.Balance.ToString("F2"),
                    }))
                    .OrderByDescending(c => c.Balance)
                    .ThenBy(c => c.FirstName)
                    .ThenBy(c => c.LastName)
                    .ToList()
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(movies, new JsonSerializerSettings()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Select(c => new ExportTopCustomersDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromSeconds(c.Tickets.Sum(t => t.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture),
                })
                .Take(10)
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportTopCustomersDto>), new XmlRootAttribute("Customers"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customers, namespaces);

                return sb.ToString().TrimEnd();
            }
        }
    }
}