using System;
using System.Configuration;
using PingPong.Communication;
using PingPong.Communication.DTOs;

namespace PingPong.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxDataSize = int.Parse(ConfigurationManager.AppSettings.Get("maxDataSize"));

            string ipAddress = args[0];
            bool numericalPort = int.TryParse(args[1], out int port);

            if (numericalPort)
            {
                var client = new TcpClientSocket(maxDataSize);

                var connectionInfo = new ConnectionInfo
                {
                    Ip = ipAddress,
                    Port = port
                };

                client.Connect(connectionInfo);
                var keepRunning = true;

                while (keepRunning)
                {
                    string userInput = Console.ReadLine();
                    client.Write(System.Text.Encoding.ASCII.GetBytes(userInput));

                    string receivedData = System.Text.Encoding.ASCII.GetString(client.Read());
                    Console.WriteLine(receivedData);
                }
            }
        }
    }
}
