using System;

public class Engine : IEngine
{
    private const string endInput = "Enough! Pull back!";

    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        string input = reader.ReadLine();
        GameController gameController = new GameController(this.writer);

        while (!input.Equals(endInput))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.AppendLine(arg.Message);
            }

            input = reader.ReadLine();
        }

        gameController.RequestResult();

        this.writer.WriteLine();
    }
}