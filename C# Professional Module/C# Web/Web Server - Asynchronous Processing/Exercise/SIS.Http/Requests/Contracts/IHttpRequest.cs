namespace SIS.Http.Requests.Contracts
{
    using SIS.Http.Enums;
    using SIS.Http.Headers.Contracts;

    using System.Collections.Generic;

    public interface IHttpRequest
    {
        string Path { get; }
        string Url { get; }
        Dictionary<string, object> FormData { get; }
        Dictionary<string, object> QueryData { get; }
        IHttpHeaderCollection Headers { get; }
        HttpRequestMethod RequestMethod { get; }
    }
}