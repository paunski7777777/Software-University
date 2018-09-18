namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            // string inputStr = Console.ReadLine();
            // int inputInt = int.Parse(Console.ReadLine());

            using (var db = new BookShopContext())
            {
                // DbInitializer.ResetDatabase(db);

                // Console.WriteLine(GetBooksByAgeRestriction(db, inputStr));
                // Console.WriteLine(GetGoldenBooks(db));
                // Console.WriteLine(GetBooksByPrice(db));
                // Console.WriteLine(GetBooksNotRealeasedIn(db, inputInt));
                // Console.WriteLine(GetBooksByCategory(db, inputStr));
                // Console.WriteLine(GetBooksReleasedBefore(db, inputStr));
                // Console.WriteLine(GetAuthorNamesEndingIn(db, inputStr));
                // Console.WriteLine(GetBookTitlesContaining(db, inputStr));
                // Console.WriteLine(GetBooksByAuthor(db, inputStr));
                // Console.WriteLine(CountBooks(db, inputInt));
                // Console.WriteLine(CountCopiesByAuthor(db));
                // Console.WriteLine(GetTotalProfitByCategory(db));
                // Console.WriteLine(GetMostRecentBooks(db));
                // IncreasePrices(db);
                // Console.WriteLine(RemoveBooks(db));
            }
        }

        // 1. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var ageRestrictionType = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var titles = context
                .Books
                .Where(ar => ar.AgeRestriction == ageRestrictionType)
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            titles.ForEach(t => sb.AppendLine(t));

            return sb.ToString().TrimEnd();
        }

        // 2. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var titles = context
                .Books
                .Where(et => et.EditionType == EditionType.Gold && et.Copies < 5000)
                .OrderBy(i => i.BookId)
                .Select(t => t.Title)
                .ToList();

            titles.ForEach(t => sb.AppendLine(t));

            return sb.ToString().TrimEnd();
        }

        // 3. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var titlesAndPrices = context
                .Books
                .Where(p => p.Price > 40)
                .OrderByDescending(p => p.Price)
                .ToList();

            titlesAndPrices.ForEach(tp => sb.AppendLine($"{tp.Title} - ${tp.Price:f2}"));

            return sb.ToString().TrimEnd();
        }

        // 4. Not Released In
        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var titles = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(i => i.BookId)
                .Select(t => t.Title)
                .ToList();

            titles.ForEach(t => sb.AppendLine(t));

            return sb.ToString().TrimEnd();
        }

        // 5. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categoryName = input.ToLower().Split().ToArray();

            var sb = new StringBuilder();

            var titles = context
                .Books
                .Where(bc => bc.BookCategories
                    .Any(c => categoryName.Contains(c.Category.Name.ToLower())))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            titles.ForEach(t => sb.AppendLine(t));

            return sb.ToString().TrimEnd();
        }

        // 6. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            string dateFormat = "dd-MM-yyyy";

            var parsedDate = DateTime.ParseExact(date, dateFormat, null);

            var books = context
                .Books
                .Where(rd => rd.ReleaseDate < parsedDate)
                .OrderByDescending(rd => rd.ReleaseDate)
                .ToList();

            books.ForEach(b => sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}"));

            return sb.ToString().TrimEnd();
        }

        // 7. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context
                .Authors
                .Where(fn => fn.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(fn => fn.FullName)
                .ToList();

            authors.ForEach(a => sb.AppendLine(a.FullName));

            return sb.ToString().TrimEnd();
        }

        // 8. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var titles = context
                .Books
                .Where(t => t.Title.ToLower().Contains(input.ToLower()))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            titles.ForEach(t => sb.AppendLine(t));

            return sb.ToString().TrimEnd();
        }

        // 9. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(i => i.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToList();

            books.ForEach(b => sb.AppendLine($"{b.Title} ({b.AuthorName})"));

            return sb.ToString().TrimEnd();
        }

        //  10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Where(t => t.Title.Length > lengthCheck)
                .Select(t => t.Title)
                .ToList()
                .Count;

            return books;
        }

        // 11. Total Book Copies 
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context
                .Authors
                .Select(b => new
                {
                    AuthorName = $"{b.FirstName} {b.LastName}",
                    BookCopies = b.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(c => c.BookCopies)
                .ToList();

            books.ForEach(b => sb.AppendLine($"{b.AuthorName} - {b.BookCopies}"));

            return sb.ToString().TrimEnd();
        }

        // 12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(b => new
                {
                    CategoryName = b.Name,
                    TotalProfit = b.CategoryBooks
                        .Sum(tp => tp.Book.Copies * tp.Book.Price)
                })
                .OrderByDescending(tp => tp.TotalProfit)
                .ThenBy(cn => cn.CategoryName)
                .ToList();

            //var categories = context
            //    .Categories
            //    .Include(cb => cb.CategoryBooks)
            //    .ThenInclude(b => b.Book)
            //    .Select(b => new
            //    {
            //        CategoryName = b.Name,
            //        TotalProfit = b.CategoryBooks.Sum(p => p.Book.Copies * p.Book.Price)
            //    })
            //    .OrderByDescending(tp => tp.TotalProfit)
            //    .ThenBy(cn => cn.CategoryName)
            //    .ToList();


            categories.ForEach(b => sb.AppendLine($"{b.CategoryName} ${b.TotalProfit:f2}"));

            return sb.ToString().TrimEnd();
        }

        // 13. Most Recent Books 
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(rd => rd.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            b.Book.Title,
                            b.Book.ReleaseDate
                        })
                        .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .OrderByDescending(cc => cc.Books.Count)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 14. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(rd => rd.ReleaseDate.Value.Year < 2010)
                .ToList();

            books.ForEach(p => p.Price += 5);

            context.SaveChanges();
        }

        // 15. Remove Books
        public static string RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(c => c.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return $"{books.Count} were deleted";
        }
    }
}