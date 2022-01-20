
namespace PingPong.Communication.Abstractions
{
    public abstract class ServerSocketBase : SocketBase
    {
        protected string Ip;

        protected int Port;

        public abstract ClientSocketBase Accept();

        public abstract void StartListening(int clientsAmount);
    }
}
