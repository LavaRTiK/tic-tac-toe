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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void створитиЛоббіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();
            //byte[] buffer = new byte[stream.Length];
            byte[] data = Encoding.UTF8.GetBytes("Create_Lobby");
            stream.Write(data, 0, data.Length);
            MessageBox.Show("Отправил");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private async Task UpdateListBox()
        {
            gameList.Clear();
            TcpClient client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("Get_Lobby");
            await stream.WriteAsync(data, 0, data.Length);
            if(stream.DataAvailable)
            {
                byte[] byteListStrng = new byte[512];
                int bytesRead = await stream.ReadAsync(byteListStrng, 0, byteListStrng.Length);
                MessageBox.Show(Encoding.UTF8.GetString(byteListStrng, 0, bytesRead));

                //StringBuilder stringBuilder = new StringBuilder(Encoding.UTF8.GetString(byteListStrng, 0, bytesRead));
                List<string> listMass = Encoding.UTF8.GetString(byteListStrng, 0, bytesRead).Split().ToList();
                while (listMass.Count != 0) 
                {
                    Lobby lob = new Lobby(listMass[0], listMass[1], listMass[2]);
                    gameList.Add(lob);
                    listMass.RemoveRange(0, 3);
                }
                //MessageBox.Show(gameList.Count.ToString());
            }
            else
            {
                return;
            }
            //Доделать передачу нейм для Обекта в сервере сделать кнопку подключения для 2 игрока , далее сама игра в Game.
        }
    }
}
