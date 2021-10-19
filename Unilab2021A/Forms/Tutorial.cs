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
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            // ステージの選択画面を表示
            Explanation explanation = new Explanation();
            this.Hide();
            explanation.Show();
        }
    }
}
