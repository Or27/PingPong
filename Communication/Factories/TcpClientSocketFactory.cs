using System.Net.Sockets;

namespace PingPong.Communication.Factories
{
    public class TcpClientSocketFactory
    {
        public TcpClientSocket Create(int maxDataSize)
        {
            return new TcpClientSocket(maxDataSize);
        }

        public TcpClientSocket Create(TcpClient socket, int maxDataSize)
        {
            return new TcpClientSocket(socket, maxDataSize);
        }
    }
}
