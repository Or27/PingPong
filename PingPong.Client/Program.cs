using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PingPong.Communication;
using PingPong.Communication.DTOs;
using PingPong.Core;

namespace PingPong.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxDataSize = int.Parse(ConfigurationManager.AppSettings.Get("maxDataSize"));
            var nameQuestion = ConfigurationManager.AppSettings.Get("nameQuestion");
            var ageQuestion = ConfigurationManager.AppSettings.Get("ageQuestion");

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

                var formatter = new BinaryFormatter();

                while (keepRunning)
                {
                    Console.WriteLine(nameQuestion);
                    string name = Console.ReadLine();

                    Console.WriteLine(ageQuestion);
                    bool numericalAge = int.TryParse(Console.ReadLine(), out int age);

                    if (numericalAge)
                    {
                        MemoryStream stream = new MemoryStream();
                        formatter.Serialize(stream, new Person(name, age));
                        client.Write(stream.ToArray());

                        byte[] receivedData = client.Read();
                        stream = new MemoryStream(receivedData);

                        var receivedPerson = (Person)formatter.Deserialize(stream);
                        Console.WriteLine(receivedPerson.ToString());
                    }
                }
            }
        }
    }
}
