namespace SIS.Http.Cookies.Contracts
{
    using SIS.Http.Cookies;

    using System.Collections.Generic;

    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void Add(HttpCookie cookie);
        bool ContainsCookie(string key);
        HttpCookie GetCookie(string key);
        bool HasCookies();
    }
}