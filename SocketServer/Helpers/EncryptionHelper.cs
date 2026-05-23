using System.Security.Cryptography;
using System.Text;

namespace SocketServer.Helpers;

public static class EncryptionHelper
{
    private static readonly string Key = "12345678901234561234567890123456";
    private static readonly string IV = "1234567890123456";

    public static string Encrypt(string plainText)
    {
        using Aes aes = Aes.Create();

        aes.Key = Encoding.UTF8.GetBytes(Key);
        aes.IV = Encoding.UTF8.GetBytes(IV);

        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using MemoryStream ms = new();
        using CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write);
        using StreamWriter sw = new(cs);

        sw.Write(plainText);
        sw.Close();

        return Convert.ToBase64String(ms.ToArray());
    }

    public static string Decrypt(string cipherText)
    {
        using Aes aes = Aes.Create();

        aes.Key = Encoding.UTF8.GetBytes(Key);
        aes.IV = Encoding.UTF8.GetBytes(IV);

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        byte[] buffer = Convert.FromBase64String(cipherText);

        using MemoryStream ms = new(buffer);
        using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
        using StreamReader sr = new(cs);

        return sr.ReadToEnd();
    }
}