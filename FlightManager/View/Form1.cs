﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightManager
{
    //Mariela
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserLogin us = new UserLogin();
            us.Show();
        }

 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoginMenu_Click(object sender, EventArgs e)
        {
            new RegisterMenu().Show();
            this.Hide();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            new FlightsList().Show();
            this.Hide();
        }
    }
}
