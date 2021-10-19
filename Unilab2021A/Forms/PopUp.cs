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
        SelectStage selectStage;
        string[] nextStages = new string[] { "1_1", "1_2", "1_3", "2_1", "2_2", "2_3", "3_1", "3_2", "3_3", "3_4", "3_5", "3_6", "3_7", "3_8", "3_9", "3_10" };
        public PopUp(GameForm gameForm, SelectStage selectStage)
        {
            InitializeComponent();
            this.gameForm = gameForm;
            this.selectStage = selectStage;
        }

        // 次のレベル
        private void button1_Click(object sender, EventArgs e)
        {
            if(gameForm.stageName == "3_10")
            {
                this.Close();
                selectStage.Show();
            }
            // 次のステージを表示
            gameForm._initialize(GetNextStage(gameForm.stageName));
            this.Close();
            gameForm.Show();
        }

        // もう一度
        private void button2_Click(object sender, EventArgs e)
        {
            gameForm._initialize(gameForm.stageName);
            this.Close();
            gameForm.Show();
        }

        // ブロックの説明
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetNextStage(string stage)
        {
            var idx = Array.IndexOf(nextStages, stage);
            return nextStages[idx + 1];
        }
    }
}
