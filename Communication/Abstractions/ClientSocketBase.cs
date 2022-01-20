

namespace PingPong.Communication.Abstractions
{
    abstract class ClientSocketBase : SocketBase
    {
        public abstract void Connect(ConnectionInfo info);
    }
}
