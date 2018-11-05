namespace SIS.WebServer.Api.Contracts
{
    using SIS.Http.Requests.Contracts;
    using SIS.Http.Responses.Contracts;

    public interface IHttpHandler
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}