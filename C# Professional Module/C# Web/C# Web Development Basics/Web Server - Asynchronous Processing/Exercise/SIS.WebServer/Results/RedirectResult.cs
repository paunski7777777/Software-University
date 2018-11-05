namespace SIS.WebServer.Results
{
    using SIS.Http.Enums;
    using SIS.Http.Headers;
    using SIS.Http.Responses;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}