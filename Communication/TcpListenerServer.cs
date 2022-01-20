using System.Net;
using System.Net.Sockets;
using PingPong.Communication.Abstractions;
using PingPong.Communication.Factories;

namespace PingPong.Communication
{
    public class TcpListenerSocket : ServerSocketBase
    {
        private TcpListener _wrappedServer;

        private TcpClientSocketFactory _clientFactory;

        public bool KeepRunning;

        public TcpListenerSocket(string ip, int port, int maxDataSize, TcpClientSocketFactory clientFactory)
        {
            Ip = ip;
            Port = port;
            MaxDataSize = maxDataSize;
            _wrappedServer = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            _clientFactory = clientFactory;
            KeepRunning = true;
        }

        public override ClientSocketBase Accept()
        {
            var socket = _wrappedServer.AcceptTcpClient();
            return _clientFactory.Create(socket, MaxDataSize);
        }

        public override void StartListening(int clientsAmount)
        {
            _wrappedServer.Start(clientsAmount);
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
