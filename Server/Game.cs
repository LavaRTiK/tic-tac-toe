using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Game
    {
        TcpClient cln1;
        TcpClient cln2;

        public Game(TcpClient cln1,TcpClient cln2)
        {
            this.cln1 = cln1;
            this.cln2 = cln2;
        }

        public async Task Start()
        {
            string[,] mass = new string[,] { {"12"," "," "}, 
                                             {" "," "," "},
                                             {" "," "," " } };

            Console.WriteLine(mass[0,0]);
        }
    }
}
