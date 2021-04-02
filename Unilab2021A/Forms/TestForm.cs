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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        //ボタンコントロール配列のフィールドを作成
        private Button[] testButtons;
        private Button button;

        private void TestForm_Load(object sender, EventArgs e)
        {

            //ボタンコントロール配列の作成（ここでは5つ作成）
            this.testButtons = new Button[5];

            //ボタンコントロールのインスタンス作成し、プロパティを設定する
            this.SuspendLayout();
            for (int i = 0; i < this.testButtons.Length; i++)
            {
                //インスタンス作成
                this.testButtons[i] = new Button();
                //プロパティ設定
                this.testButtons[i].Name = "Button" + i.ToString();
                this.testButtons[i].Text = i.ToString();
                this.testButtons[i].Size = new Size(30, 30);
                this.testButtons[i].Location = new Point(i * 30, 10);
                //イベントハンドラに関連付け
                this.testButtons[i].Click +=
                    new EventHandler(this.testButtons_Click);
            }

            //フォームにコントロールを追加
            this.Controls.AddRange(this.testButtons);
            this.ResumeLayout(false);
        }

        //Buttonのクリックイベントハンドラ
        private void testButtons_Click(object sender, EventArgs e)
        {
            //クリックされたボタンのNameを表示する
            // MessageBox.Show(((Button)sender).Name);

            this.button = new Button();
            this.button.Name = "button" + ((Button)sender).Name[6];
            this.button.Text = "button" + ((Button)sender).Name[6];
            this.button.Size = new Size(100, 30);
            this.button.Location = new Point(30, 50);
            this.Controls.Add(this.button);
        }
    }
}
