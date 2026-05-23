using System.Net;
using System.Net.Sockets;
using SocketServer.Services;

TcpListener listener = new(IPAddress.Any, 5000);

listener.Start();

Console.WriteLine("Server started on port 5000...");

while (true)
{
    TcpClient client = await listener.AcceptTcpClientAsync();

    Console.WriteLine("Client connected.");

    ClientHandler handler = new(client);

    _ = Task.Run(async () => await handler.HandleAsync());
}