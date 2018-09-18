namespace PhotoShare.Client.Core.Commands
{
    using System;
    
    using Contracts;
    using Services.Contracts;
    using PhotoShare.Client.Utilities.OutputMessages;

    public class AddTownCommand : ICommand
    {
        private const int DataLength = 2;
        private const string InvalidCommandMessage = "Command AddTown not valid!";

        private readonly ITownService townService;

        public AddTownCommand(ITownService townService)
        {
            this.townService = townService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            if (data.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string townName = data[0];
            string country = data[1];

            var townExists = this.townService.Exists(townName);

            if (townExists)
            {
                throw new ArgumentException(string.Format(AddTownMessages.TownAlreadyExistsMessage, townName));
            }

            var town = this.townService.Add(townName, country);

            string result = string.Format(AddTownMessages.SuccessMessage, townName);

            return result;
        }
    }
}