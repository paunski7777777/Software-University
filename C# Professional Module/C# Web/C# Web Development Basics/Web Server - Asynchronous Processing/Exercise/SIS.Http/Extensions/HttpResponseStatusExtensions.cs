namespace SIS.Http.Extensions
{
    using SIS.Http.Enums;

    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode statusCode) 
            => $"{(int)statusCode} {statusCode}";
    }
}