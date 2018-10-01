namespace SIS.Http.Headers
{
    using System;

    public class HttpHeader
    {
        public const string Cookie = "Cookie";
        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string ContentDisposition = "Content-Disposition";
        public const string Authorization = "Authorization";
        public const string Host = "Host";
        public const string Location = "Location";

        public string Key { get; set; }
        public string Value { get; set; }

        public HttpHeader(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}