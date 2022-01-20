
namespace PingPong.Communication.Abstractions
{
    abstract class ServerSocketBase : SocketBase
    {
        public abstract ClientSocketBase Accept();
        public abstract void StartListening(int clientsAmount);
    }
}
