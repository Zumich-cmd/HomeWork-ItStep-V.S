using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class AsyncServer
{
    private const int Port = 8888;
    private static readonly Socket ServerSocket = new(
        AddressFamily.InterNetwork,
        SocketType.Stream,
        ProtocolType.Tcp);

    static void Main()
    {
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);

        ServerSocket.Bind(endPoint);
        ServerSocket.Listen(10);

        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine($"[Server] Сервер запущено на {endPoint}");
        Console.WriteLine("[Server] Очікування клієнтів...");

        ServerSocket.BeginAccept(OnClientConnected, null);

        Console.WriteLine("[Server] Натисніть Enter для завершення роботи.");
        Console.ReadLine();

        ServerSocket.Close();
    }

    private static void OnClientConnected(IAsyncResult result)
    {
        Socket clientSocket;

        try
        {
            clientSocket = ServerSocket.EndAccept(result);
        }
        catch (ObjectDisposedException)
        {
            return;
        }

        Console.WriteLine("[Server] Клієнт підключився.");

        ServerSocket.BeginAccept(OnClientConnected, null);

        ClientState state = new ClientState
        {
            ClientSocket = clientSocket,
            Buffer = new byte[1024]
        };

        clientSocket.BeginReceive(
            state.Buffer,
            0,
            state.Buffer.Length,
            SocketFlags.None,
            OnMessageReceived,
            state);
    }

    private static void OnMessageReceived(IAsyncResult result)
    {
        ClientState state = (ClientState)result.AsyncState!;
        Socket clientSocket = state.ClientSocket;

        int bytesReceived;

        try
        {
            bytesReceived = clientSocket.EndReceive(result);
        }
        catch (SocketException)
        {
            clientSocket.Close();
            return;
        }

        if (bytesReceived == 0)
        {
            clientSocket.Close();
            return;
        }

        string message = Encoding.UTF8.GetString(state.Buffer, 0, bytesReceived);
        Console.WriteLine($"[Server] Отримано: {message}");

        string response = $"[Server] Отримано: {message}";
        byte[] responseBytes = Encoding.UTF8.GetBytes(response);

        clientSocket.BeginSend(
            responseBytes,
            0,
            responseBytes.Length,
            SocketFlags.None,
            OnResponseSent,
            clientSocket);
    }

    private static void OnResponseSent(IAsyncResult result)
    {
        Socket clientSocket = (Socket)result.AsyncState!;

        try
        {
            clientSocket.EndSend(result);
        }
        finally
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }

    private class ClientState
    {
        public Socket ClientSocket { get; set; } = null!;
        public byte[] Buffer { get; set; } = null!;
    }
}
