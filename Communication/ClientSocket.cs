using System.Net.Sockets;
using PingPong.Communication.Abstractions;
using PingPong.Communication.DTOs;

namespace Communication
{
    class ClientSocket : ClientSocketBase
    {
        private Socket _wrappedClient;

        public ClientSocket()
        {
            _wrappedClient = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public override void Connect(ConnectionInfo info)
        {
            _wrappedClient.Connect(info.Ip, info.Port);
        }

        public override byte[] Read()
        {
            byte[] receivedData = new byte[100];
            _wrappedClient.Receive(receivedData);

            return receivedData;
        }

        public override void Write(byte[] data)
        {
            _wrappedClient.Send(data);
        }
    }
}
