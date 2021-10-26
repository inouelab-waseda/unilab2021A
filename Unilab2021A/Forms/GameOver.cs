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
    public partial class GameOver : Form
    {
        GameForm gameForm;
        private GameForm nextGameForm;
        public GameOver(GameForm gf)
        {
            InitializeComponent();
            gameForm = gf;
        }

        // もう一度
        private void button1_Click(object sender, EventArgs e)
        {
            nextGameForm = new GameForm(gameForm.stageName);
            gameForm.Close();
            this.Close();
            nextGameForm.Show();
        }

        // ステージ選択
        private void button2_Click(object sender, EventArgs e)
        {
            SelectStage ss = new SelectStage();
            gameForm.Close();
            this.Close();
            ss.Show();
        }

        // ブロックの説明
        private void button3_Click(object sender, EventArgs e)
        {
            Explanation explanation = new Explanation();
            gameForm.Close();
            this.Close();
            explanation.Show();
        }
    }
}