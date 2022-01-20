using System.Net;
using System.Net.Sockets;
using PingPong.Communication.Abstractions;
using PingPong.Communication.Factories;

namespace PingPong.Communication
{
    public class ServerSocket : ServerSocketBase
    {
        private Socket _wrappedServer;

        private ClientSocketFactory _clientFactory;

        public bool KeepRunning;

        public ServerSocket(string ip, int port, int maxDataSize, ClientSocketFactory clientFactory)
        {
            Ip = ip;
            Port = port;
            MaxDataSize = maxDataSize;
            _wrappedServer = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _clientFactory = clientFactory;
            KeepRunning = true;
        }

        public override ClientSocketBase Accept()
        {
            var socket = _wrappedServer.Accept();
            return _clientFactory.Create(socket, MaxDataSize);
        }

        public override void Bind()
        {
            _wrappedServer.Bind(new IPEndPoint(IPAddress.Parse(Ip), Port));
        }

        public override void StartListening(int clientsAmount)
        {
            _wrappedServer.Listen(clientsAmount);
        }

        public void HandleClient(ClientSocketBase client)
        {
            while (KeepRunning)
            {
                byte[] recievedData = client.Read();
                client.Write(recievedData);
            }
        }
    }
}
