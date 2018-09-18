using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        public Command(string[] data)
        {
            this.data = data;
        }
        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }
 
        public abstract string Execute();
    }
}
