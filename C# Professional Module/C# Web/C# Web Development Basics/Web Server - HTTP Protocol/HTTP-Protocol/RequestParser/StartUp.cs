namespace RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var validURLs = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string urlInput = Console.ReadLine();

                if (urlInput.Equals("END"))
                {
                    break;
                }

                var urlParts = urlInput.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var path = $"/{urlParts[0]}";
                var method = urlParts[1];

                if (!validURLs.ContainsKey(path))
                {
                    validURLs[path] = new HashSet<string>();
                }

                validURLs[path].Add(method);
            }

            var requestInput = Console.ReadLine();
            var requestParts = requestInput.Split();

            var requestMethod = requestParts[0];
            var requestUrl = requestParts[1];
            var requestProtocol = requestParts[2];

            var sb = new StringBuilder();

            int statusCode = 404;
            var statusText = "NotFound";

            if (validURLs.ContainsKey(requestUrl) && validURLs[requestUrl].Contains(requestMethod.ToLower()))
            {
                statusCode = 200;
                statusText = "OK";
            }

            sb.AppendLine($"{requestProtocol} {statusCode} {statusText}");
            sb.AppendLine($"Content-Length: {statusText.Length}");
            sb.AppendLine($"Content-Type: text/plain");
            sb.AppendLine();
            sb.AppendLine(statusText);

            string result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }
    }
}