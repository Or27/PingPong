using System.Net.Sockets;
using PingPong.Communication.Abstractions;

namespace PingPong.Communication
{
    class ServerSocket : ServerSocketBase
    {
        private Socket _wrappedServer;
        private ClientSocketFactory _clientFactory;

        public ServerSocket(int maxDataSize, ClientSocketFactory clientFactory)
        {
            MaxDataSize = maxDataSize;
            _wrappedServer = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _clientFactory = clientFactory;
        }

        public override ClientSocketBase Accept()
        {
            return _wrappedServer.Accept();
        }

        public override byte[] Read()
        {
            throw new System.NotImplementedException();
        }

        public override void StartListening(int clientsAmount)
        {
            throw new System.NotImplementedException();
        }

        public override void Write(byte[] data)
        {
            throw new System.NotImplementedException();
        }
    }
}
