namespace SIS.Http.Exceptions
{
    using System;
    using System.Net;

    public class BadRequestException : Exception
    {
        private const string errorMessage = "The Request was malformed or contains unsupported elements.";

        public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

        public BadRequestException()
            : base(errorMessage) { }
    }
}