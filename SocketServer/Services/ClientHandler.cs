using System.Net.Sockets;
using System.Text;
using SocketServer.Helpers;
using SocketServer.Models;

namespace SocketServer.Services;

public class ClientHandler
{
    private readonly TcpClient _client;

    public ClientHandler(TcpClient client)
    {
        _client = client;
    }

    public async Task HandleAsync()
    {
        try
        {
            using NetworkStream stream = _client.GetStream();

            byte[] buffer = new byte[1024];

            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

            string encryptedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            string message = EncryptionHelper.Decrypt(encryptedMessage);
            Console.WriteLine($"Received: {message}");

            string[] parts = message.Split('-');

            if (parts.Length != 2)
            {
                await SendMessage(stream, "EMPTY");
                return;
            }

            string setName = parts[0];
            string keyName = parts[1];

            if (!DataStore.Data.ContainsKey(setName))
            {
                await SendMessage(stream, "EMPTY");
                return;
            }

            var subset = DataStore.Data[setName];

            if (!subset.ContainsKey(keyName))
            {
                await SendMessage(stream, "EMPTY");
                return;
            }

            int count = subset[keyName];

            for (int i = 0; i < count; i++)
            {
                string currentTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                await SendMessage(stream, currentTime);

                await Task.Delay(1000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            _client.Close();
        }
    }

    private async Task SendMessage(NetworkStream stream, string message)
    {
        string encrypted = EncryptionHelper.Encrypt(message);
     
        byte[] data = Encoding.UTF8.GetBytes(encrypted);

        await stream.WriteAsync(data, 0, data.Length);
    }
}