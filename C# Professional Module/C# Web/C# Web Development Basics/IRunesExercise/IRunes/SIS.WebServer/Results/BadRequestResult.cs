namespace SIS.WebServer.Results
{
    using SIS.Http.Enums;
    using SIS.Http.Headers;
    using SIS.Http.Responses;

    using System;
    using System.Text;

    public class BadRequestResult : HttpResponse
    {
        private const string DefaultErrorHeading = "<h1>Error of type occured, see details</h1>";

        public BadRequestResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            content = DefaultErrorHeading + Environment.NewLine + content;
            this.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}