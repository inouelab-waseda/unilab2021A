using System;
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
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
        }

        // 次のレベル
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // もう一度
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ブロックの説明
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
