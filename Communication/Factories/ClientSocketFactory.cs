
namespace Communication.Factories
{
    class ClientSocketFactory
    {
        public ClientSocket Create(int maxDataSize)
        {
            return new ClientSocket(maxDataSize);
        }
    }
}
