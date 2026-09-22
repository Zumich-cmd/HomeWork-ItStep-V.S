using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class AsyncClient
{
    private const int Port = 8888;
    private static readonly ManualResetEvent Finished = new(false);

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string clientNumber = args.Length > 0 ? args[0] : "1";
        string message = $"Клієнт {clientNumber}";

        Socket clientSocket = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);

        ClientState state = new ClientState
        {
            ClientSocket = clientSocket,
            Message = message,
            Buffer = new byte[1024]
        };

        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);

        Console.WriteLine($"[Client {clientNumber}] Підключення до сервера...");

        clientSocket.BeginConnect(serverEndPoint, OnConnected, state);

        Finished.WaitOne();
    }

    private static void OnConnected(IAsyncResult result)
    {
        ClientState state = (ClientState)result.AsyncState!;
        Socket clientSocket = state.ClientSocket;

        try
        {
            clientSocket.EndConnect(result);
            Console.WriteLine($"[Client] Підключено. Надсилаю: {state.Message}");

            byte[] messageBytes = Encoding.UTF8.GetBytes(state.Message);

            clientSocket.BeginSend(
                messageBytes,
                0,
                messageBytes.Length,
                SocketFlags.None,
                OnMessageSent,
                state);
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"[Client] Помилка підключення: {ex.Message}");
            Finished.Set();
        }
    }

    private static void OnMessageSent(IAsyncResult result)
    {
        ClientState state = (ClientState)result.AsyncState!;
        Socket clientSocket = state.ClientSocket;

        clientSocket.EndSend(result);

        clientSocket.BeginReceive(
            state.Buffer,
            0,
            state.Buffer.Length,
            SocketFlags.None,
            OnResponseReceived,
            state);
    }

    private static void OnResponseReceived(IAsyncResult result)
    {
        ClientState state = (ClientState)result.AsyncState!;
        Socket clientSocket = state.ClientSocket;

        int bytesReceived = clientSocket.EndReceive(result);

        string response = Encoding.UTF8.GetString(state.Buffer, 0, bytesReceived);
        Console.WriteLine($"[Client] Відповідь сервера: {response}");

        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();

        Finished.Set();
    }

    private class ClientState
    {
        public Socket ClientSocket { get; set; } = null!;
        public string Message { get; set; } = "";
        public byte[] Buffer { get; set; } = null!;
    }
}
