namespace SIS.Http.Responses.Contracts
{
    using SIS.Http.Cookies;
    using SIS.Http.Cookies.Contracts;
    using SIS.Http.Enums;
    using SIS.Http.Headers;
    using SIS.Http.Headers.Contracts;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        IHttpHeaderCollection Headers { get; }
        IHttpCookieCollection Cookies { get; }
        byte[] Content { get; set; }
        void AddHeader(HttpHeader header);
        void AddCookie(HttpCookie cookie);
        byte[] GetBytes();
    }
}