using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ExportDto;
using BookShop.Data;

namespace BookShop.DataProcessor
{
    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .OrderByDescending(ab => ab.Book.Price)
                    .Select(ab => new
                    {
                        BookName = ab.Book.Name,
                        BookPrice = ab.Book.Price.ToString("F2"),
                    })
                    .ToList()
                })
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(authors, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context
                .Books
                .Where(b => b.PublishedOn < date
                    && b.Genre == Genre.Science)
                .OrderBy(b => b.PublishedOn)
                .Select(b => new ExportOldestBooksDto
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                })
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.Date)
                .Take(10)
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportOldestBooksDto>), new XmlRootAttribute("Books"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, books, namespaces);

                return sb.ToString().TrimEnd();
            }
        }
    }
}