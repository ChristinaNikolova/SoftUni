using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Cinema.Data;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;

namespace Cinema.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportMovieDto> importMovieDtos = JsonConvert
                .DeserializeObject<List<ImportMovieDto>>(jsonString)
                .ToList();

            List<Movie> movies = new List<Movie>();

            foreach (ImportMovieDto importMovieDto in importMovieDtos)
            {
                if (!IsValid(importMovieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (movies.Any(m => m.Title == importMovieDto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Movie movie = new Movie()
                {
                    Title = importMovieDto.Title,
                    Director = importMovieDto.Director,
                    Duration = TimeSpan.ParseExact(importMovieDto.Duration, "c", CultureInfo.InvariantCulture),
                    Genre = Enum.Parse<Genre>(importMovieDto.Genre),
                    Rating = importMovieDto.Rating,
                };

                movies.Add(movie);

                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre.ToString(), movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportHallDto> importHallDtos = JsonConvert
                .DeserializeObject<List<ImportHallDto>>(jsonString)
                .ToList();

            List<Hall> halls = new List<Hall>();
            List<Seat> seats = new List<Seat>();

            foreach (ImportHallDto importHallDto in importHallDtos)
            {
                if (!IsValid(importHallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importHallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Hall hall = new Hall()
                {
                    Name = importHallDto.Name,
                    Is3D = importHallDto.Is3D,
                    Is4Dx = importHallDto.Is4Dx,
                };

                halls.Add(hall);

                for (int i = 0; i < importHallDto.Seats; i++)
                {
                    Seat seat = new Seat();
                    hall.Seats.Add(seat);
                    seats.Add(seat);
                }

                string projectionType = "Normal";

                projectionType = GetTheProjectionType(hall, projectionType);

                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count()));
            }

            context.Halls.AddRange(halls);
            context.Seats.AddRange(seats);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportProjectionDto>), new XmlRootAttribute("Projections"));

            using (StringReader reader = new StringReader(xmlString))
            {
                List<ImportProjectionDto> importProjectDtos =
                    (List<ImportProjectionDto>)xmlSerializer.Deserialize(reader);

                List<Projection> projections = new List<Projection>();

                foreach (ImportProjectionDto importProjectionDto in importProjectDtos)
                {
                    if (!IsValid(importProjectionDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Movie movie = context.Movies.Find(importProjectionDto.MovieId);
                    Hall hall = context.Halls.Find(importProjectionDto.HallId);

                    if (movie == null || hall == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Projection projection = new Projection()
                    {
                        MovieId = importProjectionDto.MovieId,
                        HallId = importProjectionDto.HallId,
                        DateTime = DateTime.ParseExact(importProjectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    };

                    projections.Add(projection);

                    sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                }

                context.Projections.AddRange(projections);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportCustomerDto>), new XmlRootAttribute("Customers"));

            using (StringReader reader = new StringReader(xmlString))
            {
                List<ImportCustomerDto> importCustomerDtos =
                    (List<ImportCustomerDto>)xmlSerializer.Deserialize(reader);

                List<Customer> customers = new List<Customer>();
                List<Ticket> tickets = new List<Ticket>();

                foreach (ImportCustomerDto importCustomerDto in importCustomerDtos)
                {
                    if (!IsValid(importCustomerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Customer customer = new Customer()
                    {
                        FirstName = importCustomerDto.FirstName,
                        LastName = importCustomerDto.LastName,
                        Age = importCustomerDto.Age,
                        Balance = importCustomerDto.Balance,
                    };

                    bool hasToAddCustomer = true;

                    foreach (ImportTicketDto importTicketDto in importCustomerDto.Tickets)
                    {
                        if (!IsValid(importTicketDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            hasToAddCustomer = false;
                            break;
                        }

                        Projection projection = context.Projections.Find(importTicketDto.ProjectionId);

                        if (projection == null)
                        {
                            sb.AppendLine(ErrorMessage);
                            hasToAddCustomer = false;
                            break;
                        }

                        Ticket ticket = new Ticket()
                        {
                            ProjectionId = importTicketDto.ProjectionId,
                            Price = importTicketDto.Price,
                        };

                        customer.Tickets.Add(ticket);
                    }

                    if (!hasToAddCustomer)
                    {
                        continue;
                    }

                    customers.Add(customer);
                    tickets.AddRange(customer.Tickets);

                    sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count()));
                }

                context.Customers.AddRange(customers);
                context.Tickets.AddRange(tickets);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static string GetTheProjectionType(Hall hall, string projectionType)
        {
            if (hall.Is3D && hall.Is4Dx)
            {
                projectionType = "4Dx/3D";
            }
            else if (hall.Is3D)
            {
                projectionType = "3D";
            }
            else if (hall.Is4Dx)
            {
                projectionType = "4Dx";
            }

            return projectionType;
        }
    }
}