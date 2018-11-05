namespace URL_Decode
{
    using System;
    using System.Net;

    public class StartUp
    {
        public static void Main()
        {
            string inputURL = Console.ReadLine();

            string decodedURL = WebUtility.UrlDecode(inputURL);

            Console.WriteLine(decodedURL);
        }
    }
}