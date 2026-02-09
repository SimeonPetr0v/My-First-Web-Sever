using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyFirstWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.serverListener = new TcpListener(this.ipAddress, this.port);
        }

        public void Start()
        {
            serverListener.Start();
            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine($"Listening for requests");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();
                var networkStream = connection.GetStream();
                WriteResponse(networkStream, "Hello from my server!");
                connection.Close();
            }
        }

        public void WriteResponse(NetworkStream networkStream, string message)
        {
            int contentLength = Encoding.UTF8.GetByteCount(message);
            var response = $@"HTTP/1.1 200 OK
Content-Type : text/plain; charset=UTF-8
Content-Length: {contentLength}

{message}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            int bytesRead;
            do
            {
                bytesRead = networkStream.Read(buffer, 0, bufferLength);
                requestBuilder.Append(
                    Encoding.UTF8.GetString(buffer, 0, bytesRead)
                );
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
