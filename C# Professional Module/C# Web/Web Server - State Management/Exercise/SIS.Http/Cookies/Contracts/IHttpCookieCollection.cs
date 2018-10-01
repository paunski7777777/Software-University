namespace SIS.Http.Cookies.Contracts
{
    using System;

    public interface IHttpCookieCollection
    {
        void Add(HttpCookie cookie);
        bool ContainsCookie(string key);
        HttpCookie GetCookie(string key);
        bool HasCookies();
    }
}