using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ListGame : Form
    {
        List<Lobby> gameList = new List<Lobby>();
        private string username { get; set; }
        public ListGame()
        {
            InitializeComponent();
        }
        private void ListGame_Load(object sender, EventArgs e)
        {
            Form1 usernameF = new Form1();
            while (true)
            {
                if (usernameF.ShowDialog() == DialogResult.OK)
                {
                    this.username = usernameF.GetUsername();
                    labelName.Text = $"Name:{username}";
                    break;
                }
                else
                {
                    Close();
                    break;
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Need to select lobby");
                return;
            }
            TcpClient client = new TcpClient("127.0.0.1", 9000);
            string test = listView1.SelectedItems[0].ToString();
            var stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes($"Connect_to_Lobby,{listView1.SelectedItems[0].Text},{username}");
            await stream.WriteAsync(data, 0, data.Length);
            Game game = new Game(client);
            if(game.ShowDialog() == DialogResult.OK)
            {
                //Console.WriteLine("end game");
            }
            await UpdateListBox();


        }

        private async void створитиЛоббіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();
            //byte[] buffer = new byte[stream.Length];
            byte[] data = Encoding.UTF8.GetBytes($"Create_Lobby,{username}");
            //stream.Write(data, 0, data.Length);
            stream.Write(data, 0, data.Length); 
            MessageBox.Show("Отправил");
            button1.Enabled = false;
            играToolStripMenuItem.Enabled = false;
            await UpdateListBox();
            Task<bool> task = GetStart(stream);
            bool result = await task;
            if(result == true)
            {
                Game game = new Game(client);
                if(game.ShowDialog() == DialogResult.OK)
                {

                    //Console.WriteLine("end game") ;
                }
                //MessageBox.Show("Запуск игры");
            }
            else
            {
                MessageBox.Show("Увы ошибка бля");
            }
            await UpdateListBox();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await UpdateListBox();
        }

        private async Task UpdateListBox()
        {
            gameList.Clear();
            listView1.Items.Clear();
            TcpClient client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("Get_Lobby");
            await stream.WriteAsync(data, 0, data.Length);
            if (stream.DataAvailable)
            {
                byte[] byteListStrng = new byte[512];
                int bytesRead = await stream.ReadAsync(byteListStrng, 0, byteListStrng.Length);
                MessageBox.Show(Encoding.UTF8.GetString(byteListStrng, 0, bytesRead));

                //StringBuilder stringBuilder = new StringBuilder(Encoding.UTF8.GetString(byteListStrng, 0, bytesRead));
                List<string> listMass = Encoding.UTF8.GetString(byteListStrng, 0, bytesRead).Split(',').ToList();
                while (listMass.Count != 0)
                {
                    Lobby lob = new Lobby(listMass[0], listMass[1], listMass[2]);
                    gameList.Add(lob);
                    listMass.RemoveRange(0, 3);
                }
                foreach (var list in gameList)
                {
                    ListViewItem item = new ListViewItem(new string[] {list.Name1 == username ? list.Name1+"(you)" : list.Name1,list.Name2,list.Status});
                    listView1.Items.Add(item);
                }
                //MessageBox.Show(gameList.Count.ToString());
            }
            else
            {
                return;
            }
            //Доделать передачу нейм для Обекта в сервере сделать кнопку подключения для 2 игрока , далее сама игра в Game.
        }
        public async Task<bool> GetStart(NetworkStream stream)
        {;
            byte[] data = new byte[256];
            int readbyte = await stream.ReadAsync(data, 0, data.Length);
            string command = Encoding.UTF8.GetString(data,0,readbyte);
            if(command == "start")
            {
                return true;
            }
            return false;
        }
    }
}
