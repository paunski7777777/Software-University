namespace SIS.Http.Headers.Contracts
{
    public interface IHttpHeaderCollection
    {
        void Add(HttpHeader header);
        bool ContainsHeader(string key);
        HttpHeader GetHeader(string key);
    }
}