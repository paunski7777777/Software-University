namespace SIS.Http.Responses
{
    using SIS.Http.Common;
    using SIS.Http.Enums;
    using SIS.Http.Extensions;
    using SIS.Http.Headers;
    using SIS.Http.Headers.Contracts;
    using SIS.Http.Responses.Contracts;
    
    using System.Linq;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponseStatusCode StatusCode { get; set; }
        public IHttpHeaderCollection Headers { get; private set; }
        public byte[] Content { get; set; }

        public HttpResponse() { }
        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
              .AppendLine($"{this.Headers}")
              .AppendLine();

            return sb.ToString();
        }
    }
}