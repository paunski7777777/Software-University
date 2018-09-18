namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using System;

    [Alias("filter")]
    public class PrintFilteredStudentsCommand : Command
    {
        [Inject]
        private IDatabase repository;
        public PrintFilteredStudentsCommand(string input, string[] data)
            : base(input, data)
        {
        }

        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    bool hasParsed = int.TryParse(takeQuantity, out int studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        throw new ArgumentException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        public override void Execute()
        {
            if (Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = Data[1];
            string filter = Data[2].ToLower();
            string takeCommand = Data[3].ToLower();
            string takeQuantity = Data[4].ToLower();

            this.TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
        }
    }
}
