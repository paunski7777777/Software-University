namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using PhotoShare.Client.Utilities.OutputMessages;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] data)
        {
            Console.WriteLine(ExitMessages.ExitMessage);
            Environment.Exit(0);
            return null;
        }
    }
}