namespace SIS.Http.Responses
{
    using SIS.Http.Common;
    using SIS.Http.Cookies;
    using SIS.Http.Cookies.Contracts;
    using SIS.Http.Enums;
    using SIS.Http.Headers;
    using SIS.Http.Headers.Contracts;
    using SIS.Http.Responses.Contracts;
    using SIS.Http.Extensions;

    using System.Linq;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponseStatusCode StatusCode { get; set; }
        public IHttpHeaderCollection Headers { get; }
        public IHttpCookieCollection Cookies { get; }
        public byte[] Content { get; set; }

        public HttpResponse() { }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));

            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.Headers.Add(header);
        }

        public void AddCookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));
            this.Cookies.Add(cookie);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append(this.Headers).Append(GlobalConstants.HttpNewLine);

            if (this.Cookies.HasCookies())
            {
                foreach (var httpCookie in this.Cookies)
                {
                    result.Append($"Set-Cookie: {httpCookie}").Append(GlobalConstants.HttpNewLine);
                }
            }

            result.Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}