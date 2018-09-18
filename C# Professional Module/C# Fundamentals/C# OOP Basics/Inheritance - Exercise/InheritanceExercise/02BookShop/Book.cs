using System;
using System.Text;
using System.Text.RegularExpressions;

public class Book
{
    private string title;
    private string author;
    private double price;

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }
    public string Author
    {
        get { return author; }
        set
        {
            if (value.Split().Length > 1)
            {
                string[] secondName = value.Split();
                if (Regex.IsMatch(secondName[1], @"^\d+"))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            author = value;
        }
    }
    public virtual double Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }
    public Book(string title, string author, double price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }
    public override string ToString()
    {
        var bookInfo = new StringBuilder();

        bookInfo.AppendLine($"Type: {this.GetType().Name}");
        bookInfo.AppendLine($"Title: {this.Title}");
        bookInfo.AppendLine($"Author: {this.Author}");
        bookInfo.AppendLine($"Price: {this.Price:f2}");

        return bookInfo.ToString().TrimEnd();
    }
}

