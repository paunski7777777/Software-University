namespace SIS.Framework.Routers
{
    using SIS.Http.Enums;
    using SIS.Http.Requests.Contracts;
    using SIS.Http.Responses;
    using SIS.Http.Responses.Contracts;

    using SIS.WebServer.Api.Contracts;
    using SIS.WebServer.Results;

    using System.IO;

    public class ResourceRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var httpRequestPath = request.Path;

            var indexOfStartOfExtension = httpRequestPath.LastIndexOf('.');
            var indexOfStartOfNameOfResource = httpRequestPath.LastIndexOf('/');

            var requestPathExtension = httpRequestPath
                .Substring(indexOfStartOfExtension);

            var resourceName = httpRequestPath.Substring(indexOfStartOfNameOfResource);

            var resourcePath = MvcContext.Get.RootDirectoryRelativePath
                               + $"/{MvcContext.Get.ResourceFolderName}"
                               + $"/{requestPathExtension.Substring(1)}"
                               + resourceName;

            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.Ok);
        }
    }
}
