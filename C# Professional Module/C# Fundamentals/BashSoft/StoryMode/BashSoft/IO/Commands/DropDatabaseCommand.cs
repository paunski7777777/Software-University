﻿namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    [Alias("dropdb")]
    public class DropDatabaseCommand : Command
    {
        [Inject]
        private IDatabase repository;
        public DropDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {

            if (Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
