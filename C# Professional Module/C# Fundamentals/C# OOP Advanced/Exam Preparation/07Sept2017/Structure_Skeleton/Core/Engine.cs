using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine().Split().ToList();

            string result = this.commandInterpreter.ProcessCommand(input);

            this.writer.WriteLine(result);

            if (input[0] == "Shutdown")
            {
                break;
            }
        }
    }
}
