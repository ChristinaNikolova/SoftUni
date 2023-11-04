using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                //ResetDb(context);

                //09. Import Suppliers
                //string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
                //string result = ImportSuppliers(context, inputJson);

                //10. Import Parts
                //string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
                //string result = ImportParts(context, inputJson);

                //11. Import Cars
                //string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
                //string result = ImportCars(context, inputJson);

                //12. Import Customers
                //string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
                //string result = ImportCustomers(context, inputJson);

                //13. Import Sales
                //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
                //string result = ImportSales(context, inputJson);

                //14. Export Ordered Customers
                //string result = GetOrderedCustomers(context);

                //15. Export Cars From Make Toyota
                //string result = GetCarsFromMakeToyota(context);

                //16. Export Local Suppliers
                //string result = GetLocalSuppliers(context);

                //17. Export Cars With Their List Of Parts
                //string result = GetCarsWithTheirListOfParts(context);

                //18. Export Total Sales By Customer
                //string result = GetTotalSalesByCustomer(context);

                //19. Export Sales With Applied Discount
                string result = GetSalesWithAppliedDiscount(context);

                Console.WriteLine(result);
            }
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert
                .DeserializeObject<List<Supplier>>(inputJson)
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            List<Part> parts = JsonConvert
                .DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<ImportCarDto> importCarDtos = JsonConvert
                .DeserializeObject<List<ImportCarDto>>(inputJson)
                .ToList();

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();

            foreach (ImportCarDto importCarDto in importCarDtos)
            {
                Car car = new Car()
                {
                    Make = importCarDto.Make,
                    Model = importCarDto.Model,
                    TravelledDistance = importCarDto.TravelledDistance,
                };

                cars.Add(car);

                foreach (int partId in importCarDto.PartsId.Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        PartId = partId,
                        CarId = car.Id,
                    };

                    car.PartCars.Add(partCar);
                    partCars.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert
                .DeserializeObject<List<Customer>>(inputJson)
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert
                .DeserializeObject<List<Sale>>(inputJson)
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver,
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }

        //15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count(),
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(suppliers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }

        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,
                    },
                    parts = c.PartCars
                    .Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2"),
                    })
                    .ToList()
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }

        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any(s => s.Car != null))
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Where(s => s.Car != null).Count(),
                    SpentMoney = c.Sales.Where(s => s.Car != null).Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
            });

            return jsonResult.TrimEnd();
        }

        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance,
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100).ToString("F2")
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(sales, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }

        private static void ResetDb(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}