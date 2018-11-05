namespace SIS.Http.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string BadRequestMessage = "The Request is malformed.";

        public BadRequestException() 
            : this(BadRequestMessage) { }

        public BadRequestException(string message) 
            : base(message) { }
    }
}