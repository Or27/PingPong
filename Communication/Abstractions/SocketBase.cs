
namespace Communication.Abstractions
{
    public abstract class SocketBase : IReader<byte[]>, IWriter<byte[]>
    {
        public abstract byte[] Read();

        public abstract void Write(byte[] data);
        
    }
}
