namespace ValidateURL
{
    using System;
    using System.Net;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string inputURL = Console.ReadLine();

            string invalidURL = "Invalid URL";

            var decodedURL = WebUtility.UrlDecode(inputURL);

            try
            {
                var parsedURL = new Uri(decodedURL);

                var sb = new StringBuilder();

                var protocol = parsedURL.Scheme;
                var host = parsedURL.Host;
                var port = parsedURL.Port;
                var path = parsedURL.AbsolutePath;

                var query = parsedURL.Query;
                query = query.Replace("?", "");
                query = query.Replace("&amp;", "&");

                var fragment = parsedURL.Fragment;
                fragment = fragment.Replace("#", "");

                if (string.IsNullOrWhiteSpace(protocol))
                {
                    Console.WriteLine(invalidURL);
                    Environment.Exit(0);
                }

                var validUrlForHttp = protocol == "http" && port == 80;
                var validUrlForHttps = protocol == "https" && port == 443;

                if (!validUrlForHttp && !validUrlForHttps)
                {
                    Console.WriteLine(invalidURL);
                    Environment.Exit(0);
                }

                if (string.IsNullOrWhiteSpace(host))
                {
                    Console.WriteLine(invalidURL);
                    Environment.Exit(0);
                }

                sb.AppendLine($"Protocol: {protocol}");
                sb.AppendLine($"Host: {host}");
                sb.AppendLine($"Port: {port}");
                sb.AppendLine($"Path: {path}");

                if (!string.IsNullOrWhiteSpace(query))
                {
                    sb.AppendLine($"Query: {query}");
                }

                if (!string.IsNullOrWhiteSpace(fragment))
                {
                    sb.AppendLine($"Fragment: {fragment}");
                }

                string result = sb.ToString().TrimEnd();
                Console.WriteLine(result);
            }
            catch
            {
                Console.WriteLine(invalidURL);
            }
        }
    }
}