using CarDealer.Data;
using CarDealer.ExportDtos;
using CarDealer.ImportDtos;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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
                //string inputXml = File.ReadAllText("suppliers.xml");
                //string result = ImportSuppliers(context, inputXml);

                //10. Import Parts
                //string inputXml = File.ReadAllText("parts.xml");
                //string result = ImportParts(context, inputXml);

                //11. Import Cars
                //string inputXml = File.ReadAllText("cars.xml");
                //string result = ImportCars(context, inputXml);

                //12. Import Customers
                //string inputXml = File.ReadAllText("customers.xml");
                //string result = ImportCustomers(context, inputXml);

                //13. Import Sales
                //string inputXml = File.ReadAllText("sales.xml");
                //string result = ImportSales(context, inputXml);

                //14. Export Cars With Distance
                //string result = GetCarsWithDistance(context);

                //15. Export Cars From Make BMW
                //string result = GetCarsFromMakeBmw(context);

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
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportSupplierDto>), new XmlRootAttribute("Suppliers"));

            List<ImportSupplierDto> importSupplierDtos =
                (List<ImportSupplierDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Supplier> suppliers = importSupplierDtos
                .Select(i => new Supplier()
                {
                    Name = i.Name,
                    IsImporter = i.IsImporter,
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportPartDto>), new XmlRootAttribute("Parts"));

            List<ImportPartDto> importPartDtos =
                (List<ImportPartDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Part> parts = importPartDtos
                .Where(i => context.Suppliers.Any(s => s.Id == i.SupplierId))
                .Select(i => new Part()
                {
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity,
                    SupplierId = i.SupplierId,
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportCarDto>), new XmlRootAttribute("Cars"));

            List<ImportCarDto> importCarDtos =
                (List<ImportCarDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

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

                List<int> partIds = importCarDto
                    .Parts
                    .Where(i => context.Parts.Any(p => p.Id == i.Id))
                    .Select(i => i.Id)
                    .Distinct()
                    .ToList();

                foreach (int partId in partIds)
                {
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

            return $"Successfully imported {cars.Count()}";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportCustomerDto>), new XmlRootAttribute("Customers"));

            List<ImportCustomerDto> importCustomerDtos =
                (List<ImportCustomerDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Customer> customers = importCustomerDtos
                .Select(i => new Customer()
                {
                    Name = i.Name,
                    BirthDate = i.BirthDate,
                    IsYoungDriver = i.IsYoungDriver,
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportSaleDto>), new XmlRootAttribute("Sales"));

            List<ImportSaleDto> importSaleDtos =
                (List<ImportSaleDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Sale> sales = importSaleDtos
                .Where(i => context.Cars.Any(c => c.Id == i.CarId))
                .Select(i => new Sale()
                {
                    CarId = i.CarId,
                    CustomerId = i.CustomerId,
                    Discount = i.Discount,
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        //14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportGetCarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetCarsWithDistanceDto>), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportGetCarsFromMakeBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetCarsFromMakeBmwDto>), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportGetLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count(),
                })
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetLocalSuppliersDto>), new XmlRootAttribute("suppliers"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportGetCarsWithTheirListOfPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .OrderByDescending(pc => pc.Part.Price)
                    .Select(pc => new ExportPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price,
                    })
                    .ToArray()
                })
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetCarsWithTheirListOfPartsDto>), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any(s => s.Car != null))
                .Select(c => new ExportGetTotalSalesByCustomerDto
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Where(s => s.Car != null).Count(),
                    SpentMoney = c.Sales.Where(s => s.Car != null).Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price)),
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetTotalSalesByCustomerDto>), new XmlRootAttribute("customers"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new ExportGetSalesWithAppliedDiscountDto
                {
                    Car = new ExportCarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance,
                    },
                    Discount = s.Discount,
                    Name = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100,
                })
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetSalesWithAppliedDiscountDto>), new XmlRootAttribute("sales"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static void ResetDb(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}