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
        public ListGame(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void ListGame_Load(object sender, EventArgs e)
        {

        }
    }
}
