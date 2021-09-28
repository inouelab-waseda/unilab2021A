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
    public partial class SelectStage : Form
    {
        public SelectStage()
        {
            InitializeComponent();
        }

        private void stage1Button_Click(object sender, EventArgs e)
        {
            // チュートリアル画面を表示
            Tutorial tutorial = new Tutorial();
            this.Hide();
            tutorial.ShowDialog();
        }
    }
}
