using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        static List<Lobby> list = new List<Lobby>();
        static async Task Main(string[] args)
        {
            //List<Lobby> list = new List<Lobby>();
            Console.WriteLine("Я сервер");
            try
            {
                TcpListener server = new TcpListener(IPAddress.Any, 9000);
                server.Start();
                Console.WriteLine("Server Start port 9000");

                while (true)
                {
                    Command(await server.AcceptTcpClientAsync());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server error:{ex.Message}");
            }

            Console.ReadLine();
        }
        public static async Task Command(TcpClient cln)
        {
            Console.WriteLine("что-то получил?");
            var stream = cln.GetStream();
            byte[] buffer = new byte[256];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            Console.WriteLine("Команда " + Encoding.UTF8.GetString(buffer,0,bytesRead));
            string command = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            if (command == "Create_Lobby")
            {
                Lobby lobby = new Lobby(cln, list.Count+1);
                list.Add(lobby);
            }
            if(command == "Get_Lobby")
            {
                //byte []buf = new byte[list.Count * sizeof(int)];
                //Buffer.BlockCopy(buffer, 0, list.ToArray(), 0, list.Count);
                StringBuilder strbild = new StringBuilder();
                foreach(var item in list)
                {
                    strbild.Append($"{(string.IsNullOrWhiteSpace(strbild.ToString()) ? "" : ",")}{item.Name1},{item.Name2},{item.Status}");
                }
                byte[] bytelist = Encoding.UTF8.GetBytes(strbild.ToString());
                await stream.WriteAsync(bytelist, 0, strbild.Length);
            }
            Console.WriteLine("жалко");
        }
    }
}
