using System;
public class CommandInterpreter
{
    private CustomList<string> items;
    public CommandInterpreter()
    {
        this.items = new CustomList<string>();
    }
    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            switch (command)
            {
                case "Add":
                    string itemToAdd = tokens[1];
                    this.items.Add(itemToAdd);
                    break;

                case "Remove":
                    int indexToRemove = int.Parse(tokens[1]);
                    this.items.Remove(indexToRemove);
                    break;

                case "Contains":
                    string elementContains = tokens[1];
                    Console.WriteLine(this.items.Contains(elementContains));
                    break;

                case "Swap":
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);
                    this.items.Swap(firstIndex, secondIndex);
                    break;

                case "Greater":
                    string greaterElement = tokens[1];
                    Console.WriteLine(this.items.CountGreaterThan(greaterElement));
                    break;

                case "Max":
                    Console.WriteLine(this.items.Max());
                    break;

                case "Min":
                    Console.WriteLine(this.items.Min());
                    break;

                case "Print":
                    Console.WriteLine(string.Join(Environment.NewLine, this.items));
                    break;

                case "Sort":
                    this.items.Sort();
                    break;
            }
        }
    }
}

