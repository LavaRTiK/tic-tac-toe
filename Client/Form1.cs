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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheackOnline();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(buttonOk.Text))
            {
                DialogResult = DialogResult.OK;
            }
        }
        public string GetUsername()
        {
            return textBoxName.Text;
        }
        public void CheackOnline()
        {
            try
            {
                //TcpClient tcpClient = new TcpClient("127.0.0.1", 9000);
                //tcpClient.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
            status.ForeColor = Color.Green;
            status.Text = "Online";
        }
    }
}
