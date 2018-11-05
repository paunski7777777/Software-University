namespace SIS.Http.Headers
{
    using System;

    public class HttpHeader
    {
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