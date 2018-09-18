using System;
public class CommandInterpreter
{
    private CustomClassAttribute attribute;
    public CommandInterpreter(CustomClassAttribute attribute)
    {
        this.attribute = attribute;
    }
    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            switch (input)
            {
                case "Author":
                    Console.WriteLine($"Author: {attribute.author}");
                    break;

                case "Revision":
                    Console.WriteLine($"Revision: {attribute.revision}");
                    break;

                case "Description":
                    Console.WriteLine($"Class description: {attribute.description}");
                    break;

                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attribute.reviewers)}");
                    break;
            }
        }
    }
}