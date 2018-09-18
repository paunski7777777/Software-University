namespace BashSoft
{
    using BashSoft.Contracts;
    using BashSoft.IO;
    using BashSoft.Repository;
    class StartUp
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            IInterpreter command = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(command);

            reader.StartReadingCommands();
        }
    }
}
