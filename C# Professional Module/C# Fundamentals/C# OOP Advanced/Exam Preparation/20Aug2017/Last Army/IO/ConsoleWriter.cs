using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder builder;
    public ConsoleWriter()
    {
        this.builder = new StringBuilder();
    }
    public void AppendLine(string message)
    {
        this.builder.AppendLine(message);
    }
    public void WriteLine()
    {
        Console.WriteLine(this.builder.ToString().Trim());
    }
}