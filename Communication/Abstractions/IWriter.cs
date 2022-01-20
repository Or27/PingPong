
namespace PingPong.Communication.Abstractions
{
    interface IWriter<T>
    {
        void Write(T data);
    }
}
