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
        List<string> gameList = new List<string>();
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

        private void UpdateListBox()
        {
            
        }
    }
}
