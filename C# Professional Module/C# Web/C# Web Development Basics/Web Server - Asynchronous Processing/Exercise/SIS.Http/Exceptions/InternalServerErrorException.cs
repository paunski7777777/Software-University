namespace SIS.Http.Exceptions
{
    using System;
    using System.Net;

    public class InternalServerErrorException : Exception
    {
        private const string errorMessage = "The Server has encountered an error.";

        public const HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

        public InternalServerErrorException()
            : base(errorMessage) { }
    }
}