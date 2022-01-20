using System.Net.Sockets;

namespace PingPong.Communication.Factories
{
    public class ClientSocketFactory
    {
        public ClientSocket Create(int maxDataSize)
        {
            return new ClientSocket(maxDataSize);
        }

        public ClientSocket Create(Socket socket, int maxDataSize)
        {
            return new ClientSocket(socket, maxDataSize);
        }
    }
}
