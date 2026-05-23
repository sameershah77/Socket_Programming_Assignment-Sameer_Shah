using System.Net.Sockets;
using System.Text;
using SocketClient.Helpers;

TcpClient client = new();

await client.ConnectAsync("127.0.0.1", 5000);

Console.WriteLine("Connected to server.");

using NetworkStream stream = client.GetStream();

Console.Write("Enter message (Example: SetA-Two): ");

string? input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Invalid input.");
    return;
}

string encryptedMessage = EncryptionHelper.Encrypt(input);

byte[] data = Encoding.UTF8.GetBytes(encryptedMessage);

await stream.WriteAsync(data, 0, data.Length);

byte[] buffer = new byte[1024];

while (true)
{
    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

    if (bytesRead == 0)
        break;

    string encryptedResponse = Encoding.UTF8.GetString(buffer, 0, bytesRead);

    string response = EncryptionHelper.Decrypt(encryptedResponse);

    Console.WriteLine($"Server Response: {response}");
}

client.Close();