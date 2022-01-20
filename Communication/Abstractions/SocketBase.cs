
namespace PingPong.Communication.Abstractions
{
    public abstract class SocketBase : IReader<byte[]>, IWriter<byte[]>
    {
        protected int MaxDataSize;

        public abstract byte[] Read();

        public abstract void Write(byte[] data);
    }
}
