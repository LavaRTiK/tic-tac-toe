using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Lobby
    {
        public int Id = 0;
        public TcpClient Clien1;
        public string Name1;
        public TcpClient Client2;
        public string Name2 = "Empty";
        public string Status = "Waiting for connections";
        public Lobby(TcpClient cln, int id)
        {
            this.Clien1 = cln;
            Console.WriteLine("Подключился");
        }

        public void Cheack()
        {
            if (Clien1 != null && Client2 != null)
            {
                //Gamestart
                Console.WriteLine("Запуск игры");
            }
        }
    }
}
