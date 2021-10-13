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
        GameForm gf;
        public PopUp(GameForm gf)
        {
            this.gf = gf;
            InitializeComponent();
        }

        // 次のレベル
        private void button1_Click(object sender, EventArgs e)
        {
            // 次のステージを表示（GameForm()の引数で設定？でも親というかGameFormの持ち主がPopUpになってしまう...）
            this.Close();
            GameForm gameForm = new GameForm();
            gf.Hide();
            gameForm.ShowDialog();
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
