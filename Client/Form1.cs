﻿using System;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {

        }

        private void button1Cheak_Click(object sender, EventArgs e)
        {
           
        }
        public string GetUsername()
        {
            return textBoxName.Text;
        }
    }
}
