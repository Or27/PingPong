using PingPong.Communication.DTOs;

namespace PingPong.Communication.Abstractions
{
    public abstract class ClientSocketBase : SocketBase, IReader<byte[]>, IWriter<byte[]>
    {
        public abstract void Connect(ConnectionInfo info);

        public abstract byte[] Read();

        public abstract void Write(byte[] data);
    }
}
