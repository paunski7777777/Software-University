namespace SIS.Framework.Routers
{
    using SIS.Http.Common;
    using SIS.Http.Requests.Contracts;
    using SIS.Http.Responses.Contracts;

    using SIS.WebServer.Api.Contracts;

    using System;
    using System.Linq;

    public class HttpRouteHandlingContext : IHttpHandlingContext
    {
        protected IHttpHandler ControllerHandler { get; }
        protected IHttpHandler ResourceHandler { get; }

        public HttpRouteHandlingContext(IHttpHandler controllerHandler, IHttpHandler resourceHandler)
        {
            this.ControllerHandler = controllerHandler;
            this.ResourceHandler = resourceHandler;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourceRequest(request))
            {
                return this.ResourceHandler.Handle(request);
            }

            return this.ControllerHandler.Handle(request);
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;
            if (requestPath.Contains('.'))
            {
                var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf('.'));

                return GlobalConstants.ResourceExtensions.Contains(requestPathExtension);
            }

            return false;
        }
    }
}