using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class CommandInterpreter
{
    private ListyIterator<string> listyIterator;
    public CommandInterpreter()
    {
        this.listyIterator = new ListyIterator<string>();
    }
    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        listyIterator.Create(tokens.Skip(1).ToList());
                        break;

                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;

                    case "Print":
                        listyIterator.Print();
                        break;

                    case "PrintAll":
                        Console.WriteLine(listyIterator.PrintAll());
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

