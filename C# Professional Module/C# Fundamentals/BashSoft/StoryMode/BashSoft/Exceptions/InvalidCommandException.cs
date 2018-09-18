using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    public class InvalidCommandException : Exception
    {
        private const string InvalidCommand = "The command {0} is invalid!";

        public InvalidCommandException()
            : base()
        {
        }

        public InvalidCommandException(string command)
            : base(string.Format(InvalidCommand, command))
        {
        }
    }
}
