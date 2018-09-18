namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using System;

    [Alias("order")]
    public class PrintOrderedStudentsCommand : Command
    {
        [Inject]
        private IDatabase repository;
        public PrintOrderedStudentsCommand(string input, string[] data)
            : base(input, data)
        {
        }

        private void TryParseParametersForOrderAndTake(string orderCommand, string orderQuantity, string courseName, string orderType)
        {
            if (orderCommand == "take")
            {
                if (orderQuantity == "all")
                {
                    this.repository.OrderAndTake(courseName, orderType);
                }
                else
                {
                    bool hasParsed = int.TryParse(orderQuantity, out int studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.OrderAndTake(courseName, orderType, studentsToTake);
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
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = Data[1];
            string orderType = Data[2].ToLower();
            string orderCommand = Data[3].ToLower();
            string orderQuantity = Data[4].ToLower();

            this.TryParseParametersForOrderAndTake(orderCommand, orderQuantity, courseName, orderType);
        }
    }
}
