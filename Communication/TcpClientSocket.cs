using System.Net.Sockets;
using PingPong.Communication.Abstractions;
using PingPong.Communication.DTOs;

namespace PingPong.Communication
{
    public class TcpClientSocket : ClientSocketBase
    {
        private TcpClient _wrappedClient;

        public TcpClientSocket(int maxDataSize)
        {
            MaxDataSize = maxDataSize;
            _wrappedClient = new TcpClient();
        }

        public TcpClientSocket(TcpClient wrappedClient, int maxDataSize)
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
            int bytesAmount = _wrappedClient.GetStream().Read(receivedData, 0, MaxDataSize);

            byte[] compatibleLengthData = new byte[bytesAmount];
            System.Array.Copy(receivedData, compatibleLengthData, bytesAmount);

            return compatibleLengthData;
        }

        public override void Write(byte[] data)
        {
            _wrappedClient.GetStream().Write(data, 0, data.Length);
        }
    }
}
