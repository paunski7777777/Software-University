namespace SIS.Http.Requests.Contracts
{
    using SIS.Http.Cookies.Contracts;
    using SIS.Http.Enums;
    using SIS.Http.Headers.Contracts;
    using SIS.Http.Sessions.Contracts;

    using System.Collections.Generic;

    public interface IHttpRequest
    {
        string Path { get; }
        string Url { get; }
        Dictionary<string, object> FormData { get; }
        Dictionary<string, object> QueryData { get; }
        IHttpHeaderCollection Headers { get; }
        IHttpCookieCollection Cookies { get; }
        HttpRequestMethod RequestMethod { get; }
        IHttpSession Session { get; set; }
    }
}