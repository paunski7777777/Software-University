namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    [Alias("cdabs")]
    public class ChangeAbsolutePathCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;
        public ChangeAbsolutePathCommand(string input, string[] data)
            : base(input, data) { }

        public override void Execute()
        {
            if (Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string absolutePath = Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }
    }
}
