using System.Threading.Tasks;
using System.Configuration;
using PingPong.Communication;
using PingPong.Communication.Factories;

namespace PingPong.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string ipAddress = ConfigurationManager.AppSettings.Get("ip");
            var maxDataSize = int.Parse(ConfigurationManager.AppSettings.Get("maxDataSize"));
            var listenAmount = int.Parse(ConfigurationManager.AppSettings.Get("listenAmount"));

            bool numericalPort = int.TryParse(args[0], out int port);

            if (numericalPort)
            {
                var clientsFactory = new ClientSocketFactory();
                var server = new ServerSocket(ipAddress, port, maxDataSize, clientsFactory);

                server.Bind();
                server.StartListening(listenAmount);

                while (server.KeepRunning)
                {
                    var client = server.Accept();
                    Task.Run(() => server.HandleClient(client));
                }
            }
        }
    }
}
