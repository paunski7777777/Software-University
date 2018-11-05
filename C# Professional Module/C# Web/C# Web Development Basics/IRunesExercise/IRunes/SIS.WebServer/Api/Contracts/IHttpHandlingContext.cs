namespace SIS.WebServer.Api.Contracts
{
    using SIS.Http.Requests.Contracts;
    using SIS.Http.Responses.Contracts;

    public interface IHttpHandlingContext
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}