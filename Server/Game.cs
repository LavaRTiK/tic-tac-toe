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
        int cout;

        public Game(TcpClient cln1,TcpClient cln2)
        {
            this.cln1 = cln1;
            this.cln2 = cln2;
        }

        public async Task Start()
        {
            string[,] mass = new string[,] { {" "," "," "}, 
                                             {" "," "," "},
                                             {" "," "," " } };
            byte[] data;
            Random random = new Random();
            var streamcln1 = cln1.GetStream();
            var streamcln2 = cln2.GetStream();
            string znakcl1 = "";
            string znakcl2 = "";
            int whoFirst = 0;//random.Next(0, 2);
            if (whoFirst == 0)
            {
                Console.WriteLine("who first 0");
                data = Encoding.UTF8.GetBytes("first");
                await streamcln1.WriteAsync(data, 0, data.Length);
                znakcl1 = "X";
                znakcl2 = "O";
            }
            else
            {
                Console.WriteLine("who first 1");
                data = Encoding.UTF8.GetBytes("first");
                await streamcln2.WriteAsync(data, 0, data.Length);
                znakcl1 = "O";
                znakcl2 = "X";
            }
            while (true)
            {
                try
                {
                    if (streamcln1.DataAvailable)
                    {
                        byte[] pos = new byte[256];
                        int readbytes = await streamcln1.ReadAsync(pos, 0, pos.Length);
                        string[] massPos = Encoding.UTF8.GetString(pos, 0, readbytes).Split(',');
                        string poss = Encoding.UTF8.GetString(pos, 0, readbytes);
                        byte[] byteWritepos = Encoding.UTF8.GetBytes(poss);
                        mass[Convert.ToInt32(massPos[0]), Convert.ToInt32(massPos[1])] = znakcl1;
                        //Console.WriteLine($"Прочиал {massPos[0]},{massPos[1]}");
                        cout++;
                        string winner = await CheackWhyWin(mass, znakcl1, znakcl2);
                        if (winner == "X" || winner == "O" || winner == "=")
                        {
                            byte[] win = Encoding.UTF8.GetBytes(poss+","+ winner);
                            await streamcln2.WriteAsync(win, 0, win.Length);
                            await streamcln1.WriteAsync(win, 0, win.Length);
                            Console.WriteLine("Выграл" + winner);
                            break;
                        }
                        else
                        {
                            await streamcln2.WriteAsync(byteWritepos, 0, byteWritepos.Length);
                            Console.WriteLine($"Прочиал {massPos[0]},{massPos[1]}");
                        }
                    }
                    else if (streamcln2.DataAvailable)
                    {
                        byte[] pos = new byte[256];
                        int readbytes = await streamcln2.ReadAsync(pos, 0, pos.Length);
                        string[] massPos = Encoding.UTF8.GetString(pos, 0, readbytes).Split(',');
                        string poss = Encoding.UTF8.GetString(pos, 0, readbytes);
                        byte [] byteWritepos = Encoding.UTF8.GetBytes(poss);
                        mass[Convert.ToInt32(massPos[0]), Convert.ToInt32(massPos[1])] = znakcl2;
                        cout++;
                        string winner = await CheackWhyWin(mass, znakcl1, znakcl2);
                        if (winner == "X" || winner == "O")
                        {
                            byte[] win = Encoding.UTF8.GetBytes(poss+","+ winner);
                            await streamcln1.WriteAsync(win, 0, win.Length);
                            await streamcln2.WriteAsync(win, 0, win.Length);
                            Console.WriteLine("Выграл" + winner);
                            break;
                        }
                        else
                        {
                            await streamcln1.WriteAsync(byteWritepos, 0, byteWritepos.Length);
                            Console.WriteLine($"Прочиал {massPos[0]},{massPos[1]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private async Task<string> CheackWhyWin(string[,] mass,string znakcl1,string znakcl2)
        {
            bool winForZnak1 =
                (mass[0,0] == znakcl1 && mass[0, 1] == znakcl1 && mass[0, 2] == znakcl1) || // Проверка по горизонтали
                (mass[1, 0] == znakcl1 && mass[1, 1] == znakcl1 && mass[1, 2] == znakcl1) ||
                (mass[2, 0] == znakcl1 && mass[2, 1] == znakcl1 && mass[2, 2] == znakcl1) ||
                (mass[0, 0] == znakcl1 && mass[1, 0] == znakcl1 && mass[2, 0] == znakcl1) || // Проверка по вертикали
                (mass[0, 1] == znakcl1 && mass[1, 1] == znakcl1 && mass[2, 1] == znakcl1) ||
                (mass[0, 2] == znakcl1 && mass[1, 2] == znakcl1 && mass[2, 2] == znakcl1) ||
                (mass[0, 0] == znakcl1 && mass[1, 1] == znakcl1 && mass[2, 2] == znakcl1) || // Проверка по диагонали
                (mass[0, 2] == znakcl1 && mass[1, 1] == znakcl1 && mass[2, 0] == znakcl1);

            // Проверка выигрыша для второго знака
            bool winForZnak2 =
                (mass[0, 0] == znakcl2 && mass[0, 1] == znakcl2 && mass[0, 2] == znakcl2) || // Проверка по горизонтали
                (mass[1, 0] == znakcl2 && mass[1, 1] == znakcl2 && mass[1, 2] == znakcl2) ||
                (mass[2, 0] == znakcl2 && mass[2, 1] == znakcl2 && mass[2, 2] == znakcl2) ||
                (mass[0, 0] == znakcl2 && mass[1, 0] == znakcl2 && mass[2, 0] == znakcl2) || // Проверка по вертикали
                (mass[0, 1] == znakcl2 && mass[1, 1] == znakcl2 && mass[2, 1] == znakcl2) ||
                (mass[0, 2] == znakcl2 && mass[1, 2] == znakcl2 && mass[2, 2] == znakcl2) ||
                (mass[0, 0] == znakcl2 && mass[1, 1] == znakcl2 && mass[2, 2] == znakcl2) || // Проверка по диагонали
                (mass[0, 2] == znakcl2 && mass[1, 1] == znakcl2 && mass[2, 0] == znakcl2);
            if(winForZnak1)
            {
                return znakcl1;
            }
            else if(winForZnak2)
            {
                return znakcl2;
            }
            if (cout == 9)
            {
                return "=";
            }
            return "";
        }
    }
}
