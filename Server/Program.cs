using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Я сервер");
            try
            {
                TcpListener server = new TcpListener(IPAddress.Any, 9000);
                server.Start();
                Console.WriteLine("Server Start port 9000");

                while (true)
                {
                    await server.AcceptTcpClientAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server error:{ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
