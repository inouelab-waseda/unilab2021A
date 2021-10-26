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
        GameForm gameForm;
        private GameForm nextGameForm;
        string[] nextStages = new string[] { "1_1", "1_2", "1_3", "2_1", "2_2", "2_3", "3_1", "3_2", "3_3", "3_4", "3_5", "3_6", "3_7", "3_8", "3_9", "3_10" };
        public PopUp(GameForm gf)
        {
            InitializeComponent();
            gameForm = gf;
        }

        // 次のレベル
        private void button1_Click(object sender, EventArgs e)
        {
            if(gameForm.stageName == "3_10")
            {
                SelectStage selectStage = new SelectStage();
                this.Close();
                selectStage.Show();
            }
            // 次のステージを表示
            nextGameForm = new GameForm(GetNextStage(gameForm.stageName));
            gameForm.Close();
            this.Close();
            nextGameForm.Show();
        }

        // もう一度
        private void button2_Click(object sender, EventArgs e)
        {
            nextGameForm = new GameForm(gameForm.stageName);
            gameForm.Close();
            this.Close();
            nextGameForm.Show();
        }

        // ステージ選択
        private void button3_Click(object sender, EventArgs e)
        {
            // ステージの選択画面を表示
            SelectStage ss = new SelectStage();
            gameForm.Close();
            this.Close();
            ss.Show();
        }

        private string GetNextStage(string stage)
        {
            var idx = Array.IndexOf(nextStages, stage);
            return nextStages[idx + 1];
        }
    }
}
