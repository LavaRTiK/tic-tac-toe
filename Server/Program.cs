using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
                    await Command(await server.AcceptTcpClientAsync());

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
            try
            {


                var stream = cln.GetStream();
                byte[] buffer = new byte[256];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string[] answer = Encoding.UTF8.GetString(buffer, 0, bytesRead).Split(',');
                if (answer.Length > 1)
                {
                    Console.WriteLine("Команда с параиетром " + Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }
                else
                {
                    Console.WriteLine("Команда " + Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }
                string command = answer[0];
                if (command == "Create_Lobby")
                {
                    Lobby lobby = new Lobby(cln, answer[1], list.Count + 1);
                    list.Add(lobby);
                }
                if (command == "Get_Lobby")
                {
                    //byte []buf = new byte[list.Count * sizeof(int)];
                    //Buffer.BlockCopy(buffer, 0, list.ToArray(), 0, list.Count);
                    StringBuilder strbild = new StringBuilder();
                    foreach (var item in list)
                    {
                        strbild.Append($"{(string.IsNullOrWhiteSpace(strbild.ToString()) ? "" : ",")}{item.Name1},{item.Name2},{item.Status}");
                    }
                    Console.WriteLine(strbild.ToString());
                    byte[] bytelist = Encoding.UTF8.GetBytes(strbild.ToString());
                    await stream.WriteAsync(bytelist, 0, strbild.Length);
                }
                if(command == "Connect_to_Lobby")
                {
                    var lobby = list.FirstOrDefault(x => x.Name1 == answer[1]);
                    lobby.Client2 = cln;
                    lobby.Name2 = answer[2];
                    Console.WriteLine(answer[1]);
                    Console.WriteLine(answer[2]);
                    Console.WriteLine("----------------");
                    foreach(var item in list)
                    {
                        Console.WriteLine(item.Name2);
                    }
                    lobby.Cheack();
                    var streamcl = lobby.Clien1.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes("start");
                    await streamcl.WriteAsync(data, 0, data.Length);
                    Console.WriteLine("Отправлено");
                    //Запуск роботает сделать запуск клинету подключения (создать логику игры)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Console.WriteLine("жалко");



        }
    }
}
