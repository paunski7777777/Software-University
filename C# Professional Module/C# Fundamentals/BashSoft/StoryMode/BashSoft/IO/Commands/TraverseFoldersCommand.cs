namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using System;

    [Alias("ls")]
    public class TraverseFoldersCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;
        public TraverseFoldersCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (Data.Length == 1)
            {
                this.inputOutputManager.TraverseDirectory(0);
            }
            else if (Data.Length == 2)
            {
                bool hasParsed = int.TryParse(Data[1], out int depth);
                if (hasParsed)
                {
                    this.inputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.UnableToParseNumber);
                }
            }
        }
    }
}
