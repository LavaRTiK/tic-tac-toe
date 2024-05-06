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
    public partial class Game : Form
    {
        Button[,] mass;
        TcpClient cln;
        string znak;
        string znak2;
        public Game(TcpClient cln)
        {
            InitializeComponent();
            this.cln = cln;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            mass = new Button[,]{ {button0_0,button0_1,button0_2}, 
                                          {button1_0,button1_1,button1_2 }, 
                                          {button2_0,button2_1,button2_2 } };
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            GamedCkeck();
        }
        private async void GamedCkeck()
        {
            var stream = cln.GetStream();
            if (stream.DataAvailable)
            {
                byte[] data = new byte[256];
                int readbyte = await stream.ReadAsync(data, 0, data.Length);
                string command = Encoding.UTF8.GetString(data, 0, readbyte);
                if (command == "first")
                {
                    //MessageBox.Show("я перевий");
                    znak = "X";
                    znak2 = "O";
                    foreach (var item in mass)
                    {
                        if (string.IsNullOrEmpty(item.Text))
                        {
                            item.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show("я не перевий");
                znak = "O";
                znak2 = "X";
                await waitCurrent();
            }
        }

        private async void button0_0_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("0,0");
            await stream.WriteAsync(data,0,data.Length);
            button0_0.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();
        }

        private async void button0_1_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("0,1");
            await stream.WriteAsync(data, 0, data.Length);
            button0_1.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();
        }

        private async void button0_2_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("0,2");
            await stream.WriteAsync(data, 0, data.Length);
            button0_2.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();
        }

        private async void button1_0_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("1,0");
            await stream.WriteAsync(data, 0, data.Length);
            button1_0.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();
        }

        private async void button1_1_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("1,1");
            await stream.WriteAsync(data, 0, data.Length);
            button1_1.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();
        }

        private async void button1_2_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("1,2");
            await stream.WriteAsync(data, 0, data.Length);
            button1_2.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();

        }

        private async void button2_0_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("2,0");
            await stream.WriteAsync(data, 0, data.Length);
            button2_0.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();
        }

        private async void button2_1_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("2,1");
            await stream.WriteAsync(data, 0, data.Length);
            button2_1.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();
        }

        private async void button2_2_Click(object sender, EventArgs e)
        {
            var stream = cln.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("2,2");
            await stream.WriteAsync(data, 0, data.Length);
            button2_2.Text = znak;
            foreach (var item in mass)
            {
                item.Enabled = false;
            }
            await waitCurrent();
        }
        private async Task  waitCurrent()
        {
            var stream = cln.GetStream();
            byte[] data = new byte[256];
            int readsbyte = await stream.ReadAsync(data,0,data.Length);
            string [] masspos = Encoding.UTF8.GetString(data,0,readsbyte).Split(',');
            //MessageBox.Show($"Я прочитал{masspos[0]},{masspos[1]}");
            if (masspos.Length > 2)
            {
                //MessageBox.Show($"Я прочитал{masspos[0]},{masspos[1]},{masspos[2]}");
                if (znak == masspos[2])
                {
                    //mass[Convert.ToInt32(masspos[0]), Convert.ToInt32(masspos[1])].Text = znak2;
                    foreach (var item in mass)
                    {
                        if (string.IsNullOrEmpty(item.Text))
                        {
                            item.Enabled = false;
                        }
                    }
                    MessageBox.Show("You win");
                    DialogResult = DialogResult.OK;
                    return;
                }
                else if (masspos[2] == "=")
                {
                    MessageBox.Show("Draw");
                    DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    mass[Convert.ToInt32(masspos[0]), Convert.ToInt32(masspos[1])].Text = znak2;
                    foreach (var item in mass)
                    {
                        if (string.IsNullOrEmpty(item.Text))
                        {
                            item.Enabled = false;
                        }
                    }
                    MessageBox.Show("You lost");
                    DialogResult = DialogResult.OK;
                    return;
                }
            }
            else
            {
                mass[Convert.ToInt32(masspos[0]), Convert.ToInt32(masspos[1])].Text = znak2;
                foreach (var item in mass)
                {
                    if (string.IsNullOrEmpty(item.Text))
                    {
                        item.Enabled = true;
                    }
                }
            }
            //MessageBox.Show($"Я прочитал{masspos[0]},{masspos[1]}");
            //MessageBox.Show("Я просто себался");

        }
    }
}
