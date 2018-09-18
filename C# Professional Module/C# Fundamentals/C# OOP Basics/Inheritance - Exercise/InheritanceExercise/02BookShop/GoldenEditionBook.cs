using System;
public class GoldenEditionBook : Book
{
    public override double Price { get => base.Price * 1.3; }
    public GoldenEditionBook(string title, string author, double price) : base(title, author, price)
    {

    }
}

