﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unilab2021A.Forms
{
    public partial class GameHome : Form
    {
        public GameHome()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // チュートリアルを表示
            Tutorial tutorial = new Tutorial();
            this.Hide();
            tutorial.Show();
        }
    }
}
