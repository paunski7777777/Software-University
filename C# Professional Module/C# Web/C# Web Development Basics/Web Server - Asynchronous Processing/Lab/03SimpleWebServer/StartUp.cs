namespace _03SimpleWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main()
        {
            var ip = IPAddress.Parse("127.0.0.1");
            int port = 1300;
            var listener = new TcpListener(ip, port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at 127.0.0.1:{port}");

            var task = Task.Run(() => ConnectWithTcpClient(listener));
            task.Wait();
        }

        public static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected.");

                byte[] buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                string message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(message.Trim('\0'));

                string responseMessage = "HTTP/1.1 200 OK\nContent-Type: text/plain\n\nHello from server!";
                byte[] data = Encoding.UTF8.GetBytes(responseMessage);
                await client.GetStream().WriteAsync(buffer, 0, buffer.Length);

                Console.WriteLine("Closing connection.");
                client.Dispose();
            }
        }
    }
}