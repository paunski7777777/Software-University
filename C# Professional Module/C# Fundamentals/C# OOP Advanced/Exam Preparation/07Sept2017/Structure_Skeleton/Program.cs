public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IHarvesterController harvesterController = new HarvesterController(energyRepository, harvesterFactory);
        IProviderFactory providerFactory = new ProviderFactory();
        IProviderController providerController = new ProviderController(energyRepository);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);
        Engine engine = new Engine(commandInterpreter, reader, writer);
        engine.Run();
    }
}