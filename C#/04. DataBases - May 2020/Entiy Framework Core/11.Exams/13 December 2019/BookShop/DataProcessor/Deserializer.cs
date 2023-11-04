using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;
using BookShop.Data;

namespace BookShop.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportBookDto>), new XmlRootAttribute("Books"));

            List<ImportBookDto> importBookDtos =
                (List<ImportBookDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Book> books = new List<Book>();

            foreach (ImportBookDto importBookDto in importBookDtos)
            {
                if (!IsValid(importBookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isPublishDateValid = DateTime.TryParseExact(importBookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishDate);

                if (!isPublishDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book()
                {
                    Name = importBookDto.Name,
                    Pages = importBookDto.Pages,
                    PublishedOn = publishDate,
                    Price = importBookDto.Price,
                    Genre = (Genre)importBookDto.Genre,
                };

                books.Add(book);

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportAuthorDto> importAuthorDtos = JsonConvert
                .DeserializeObject<List<ImportAuthorDto>>(jsonString)
                .ToList();

            List<Author> authors = new List<Author>();
            List<AuthorBook> authorBooks = new List<AuthorBook>();

            foreach (ImportAuthorDto importAuthor in importAuthorDtos)
            {
                if (!IsValid(importAuthor))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(a => a.Email == importAuthor.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = importAuthor.FirstName,
                    LastName = importAuthor.LastName,
                    Phone = importAuthor.Phone,
                    Email = importAuthor.Email,
                };

                foreach (ImportAuthorBookDto importAuthorBookDto in importAuthor.Books)
                {
                    if (!importAuthorBookDto.Id.HasValue)
                    {
                        continue;
                    }

                    Book book = context.Books.Find(importAuthorBookDto.Id.Value);

                    if (book == null)
                    {
                        continue;
                    }

                    AuthorBook authorBook = new AuthorBook()
                    {
                        AuthorId = author.Id,
                        BookId = book.Id,
                    };

                    author.AuthorsBooks.Add(authorBook);
                }

                if (author.AuthorsBooks.Count() == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                authorBooks.AddRange(author.AuthorsBooks);

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count()));
            }

            context.Authors.AddRange(authors);
            context.AuthorsBooks.AddRange(authorBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}