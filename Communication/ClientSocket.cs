using System.Net.Sockets;
using PingPong.Communication.Abstractions;
using PingPong.Communication.DTOs;

namespace PingPong.Communication
{
    public class ClientSocket : ClientSocketBase
    {
        private Socket _wrappedClient;

        public ClientSocket(int maxDataSize)
        {
            MaxDataSize = maxDataSize;
            _wrappedClient = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public ClientSocket(Socket wrappedClient, int maxDataSize)
        {
            MaxDataSize = maxDataSize;
            _wrappedClient = wrappedClient;
        }

        public override void Connect(ConnectionInfo info)
        {
            _wrappedClient.Connect(info.Ip, info.Port);
        }

        public override byte[] Read()
        {
            byte[] receivedData = new byte[MaxDataSize];
            int bytesAmount = _wrappedClient.Receive(receivedData);

            byte[] compatibleLengthData = new byte[bytesAmount];
            System.Array.Copy(receivedData, compatibleLengthData, bytesAmount);

            return compatibleLengthData;
        }

        public override void Write(byte[] data)
        {
            _wrappedClient.Send(data);
        }
    }
}
