namespace SIS.WebServer.Results
{
    using SIS.Http.Enums;
    using SIS.Http.Headers;
    using SIS.Http.Responses;

    using System.Text;

    public class UnauthorizedResult : HttpResponse
    {

        private const string DefaultErrorHeading = "<h1>You have no premission to access this functionality</h1>";

        public UnauthorizedResult()
            : base(HttpResponseStatusCode.Unauthorized)
        {
            this.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html"));
            this.Content = Encoding.UTF8.GetBytes(DefaultErrorHeading);
        }
    }
}