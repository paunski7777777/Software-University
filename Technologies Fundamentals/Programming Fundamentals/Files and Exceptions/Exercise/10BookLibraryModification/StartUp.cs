namespace _10BookLibraryModification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    using System.IO;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputFile = File.ReadAllLines("input.txt");

            var books = new List<Book>();

            for (int i = 1; i < inputFile.Length; i++)
            {
                books.Add(ReadBook(inputFile[i]));
            }

            DateTime targetReleaseDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var titles = books
                        .Where(b => b.ReleaseDate > targetReleaseDate)
                        .OrderBy(b => b.ReleaseDate).ThenBy(b => b.Title)
                        .Select(b => b.Title)
                        .Distinct()
                        .ToArray();

            foreach (string t in titles)
            {
                DateTime[] dates = books
                                  .Where(b => b.Title == t && b.ReleaseDate > targetReleaseDate)
                                  .OrderBy(b => b.ReleaseDate)
                                  .Select(b => b.ReleaseDate)
                                  .Distinct()
                                  .ToArray();

                foreach (DateTime d in dates)
                {
                    File.AppendAllText("output.txt", $"{t} -> {d.ToString("dd.MM.yyyy")}");
                    File.AppendAllText("output.txt", Environment.NewLine);
                }
            }
        }

        private static Book ReadBook(string input)
        {
            string[] tokens = input.Split();

            string title = tokens[0];
            string author = tokens[1];
            string publisher = tokens[2];
            DateTime releaseDate = DateTime.ParseExact(tokens[3], "d.M.yyyy", CultureInfo.InvariantCulture);
            int isbn = int.Parse(tokens[4]);
            double price = double.Parse(tokens[5]);

            return new Book { Title = title, Author = author, Publisher = publisher, ReleaseDate = releaseDate, ISBN = isbn, Price = price };
        }
    }

    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ISBN { get; set; }
        public double Price { get; set; }
    }
}