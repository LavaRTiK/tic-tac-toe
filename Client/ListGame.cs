using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ListGame : Form
    {
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
                    MessageBox.Show(username);
                    break;
                }
                else
                {
                    Close();
                    break;
                }
            }
        }
    }
}
