using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;
    private bool isRunning;
    public Engine()
    {
        this.draftManager = new DraftManager();
        this.isRunning = true;
    }
    public void Run()
    {
        while (isRunning)
        {
            var tokens = Console.ReadLine().Split().ToList();
            string command = tokens[0];
            tokens.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(tokens));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(tokens));
                    break;

                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;

                case "Mode":
                    Console.WriteLine(draftManager.Mode(tokens));
                    break;

                case "Check":
                    Console.WriteLine(draftManager.Check(tokens));
                    break;

                case "Shutdown":
                    Console.WriteLine(draftManager.ShutDown());
                    isRunning = false;
                    break;
            }
        }
    }
}

