namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //1. Age Restriction
            //string result = GetBooksByAgeRestriction(db, "miNor");
            //Console.WriteLine(result);

            //2. Golden Books
            //string result = GetGoldenBooks(db);
            //Console.WriteLine(result);

            //3. Books by Price
            //string result = GetBooksByPrice(db);
            //Console.WriteLine(result);

            //4. Not Released In
            //string result = GetBooksNotReleasedIn(db, 2000);
            //Console.WriteLine(result);

            //5. Book Titles by Category
            //string result = GetBooksByCategory(db, "horror mystery drama");
            //Console.WriteLine(result);

            //6. Released Before Date
            //string result = GetBooksReleasedBefore(db, "12-04-1992");
            //Console.WriteLine(result);

            //7. Author Search
            //string result = GetAuthorNamesEndingIn(db, "e");
            //Console.WriteLine(result);

            //8. Book Search
            //string result = GetBookTitlesContaining(db, "sK");
            //Console.WriteLine(result);

            //9. Book Search by Author
            //string result = GetBooksByAuthor(db, "R");
            //Console.WriteLine(result);

            //10. Count Books
            //int result = CountBooks(db, 12);
            //Console.WriteLine(result);

            //11. Total Book Copies
            //string result = CountCopiesByAuthor(db);
            //Console.WriteLine(result);

            //12. Profit by Category
            //string result = GetTotalProfitByCategory(db);
            //Console.WriteLine(result);

            //13. Most Recent Books
            //string result = GetMostRecentBooks(db);
            //Console.WriteLine(result);

            //14. Increase Prices
            //IncreasePrices(db);

            //15. Remove Books
            int result = RemoveBooks(db);
            Console.WriteLine(result);
        }

        //1. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestrictionInput = Enum.Parse<AgeRestriction>(command, ignoreCase: true);

            List<string> titles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestrictionInput)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, titles);

            return result.TrimEnd();
        }

        //2. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> titles = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold
                         && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, titles);

            return result.TrimEnd();
        }

        //3. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    Price = b.Price.ToString("F2")
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books
                .Select(b => $"{b.Title} - ${b.Price}"));

            return result.TrimEnd();
        }

        //4. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            List<string> titles = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, titles);

            return result.TrimEnd();
        }

        //5. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            List<string> titles = context
                .Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, titles);

            return result.TrimEnd();
        }

        //6. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    Price = b.Price.ToString("F2"),
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price}"));

            return result.TrimEnd();
        }

        //7. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            List<string> authorsFullNames = context
                .Authors
                .Where(a => EF.Functions.Like(a.FirstName, $"%{input}"))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            string result = string.Join(Environment.NewLine, authorsFullNames);

            return result.TrimEnd();
        }

        //8. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            List<string> titles = context
                .Books
                .Where(b => EF.Functions.Like(b.Title.ToLower(), $"%{input.ToLower()}%"))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, titles);

            return result.TrimEnd();
        }

        //9. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => EF.Functions.Like(b.Author.LastName.ToLower(), $"{input.ToLower()}%"))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName,
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books
                .Select(b => $"{b.Title} ({b.AuthorFirstName} {b.AuthorLastName})"));

            return result.TrimEnd();
        }

        //10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int countBooks = context
                .Books
                .Count(b => b.Title.Length > lengthCheck);

            return countBooks;
        }

        //11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies),
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

            string result = string.Join(Environment.NewLine, authors
                .Select(a => $"{a.FirstName} {a.LastName} - {a.TotalCopies}"));

            return result.TrimEnd();
        }

        //12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies),
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            string result = string.Join(Environment.NewLine, categories
                .Select(c => $"{c.Name} ${c.TotalProfit:F2}"));

            return result.TrimEnd();
        }

        //13. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate.Value)
                    .Take(3)
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate.Value.Year,
                    })
                    .ToList()
                })
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    result.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return result.ToString().TrimEnd();
        }

        //14. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            List<Book> booksToUpdatePrices = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (Book book in booksToUpdatePrices)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            List<Book> booksToRemove = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int countRemovedBooks = booksToRemove.Count();

            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();

            return countRemovedBooks;
        }
    }
}
