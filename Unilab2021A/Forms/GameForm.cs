using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//完成に向けてすること------------------------------------------------------------------------
//max_countはtextboxで、何回繰り返すかを書く→あとからこれを矢印の画像に対応するように変更
//count_labelは、繰り返し回数の計測→あとから工夫して消去したい
//----------------------------------------------------------------------------------------------

namespace Unilab2021A.Forms
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //画像ファイルを読み込んで、Imageオブジェクトとして取得する
            Image img = Image.FromFile(@".\Images\Player_Right.jpg");
            //画像をcanvasの座標(0, 10)の位置に描画する
            g.DrawImage(img, 0, 10, img.Width/2, img.Height/2);
            //Imageオブジェクトのリソースを解放する
            img.Dispose();

            //Graphicsオブジェクトのリソースを解放する
            g.Dispose();
            //PictureBox1に表示する
            pictureBox1.Image = canvas;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cout_labelは繰り返し回数のカウント用
            cout_label.Text = "1";
   
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //画像ファイルを読み込んで、Imageオブジェクトとして取得する
            Image img = Image.FromFile(@".\Images\Player_Right.jpg");
            //画像をcanvasの座標(0, 10)の位置に描画する
            g.DrawImage(img, 0, 10, img.Width / 2, img.Height / 2);
            //Imageオブジェクトのリソースを解放する
            img.Dispose();

            //Graphicsオブジェクトのリソースを解放する
            g.Dispose();
            //PictureBox1に表示する
            pictureBox1.Image = canvas;

            //timerをスタート
            timer1.Enabled = true;

        }

        //描画をtimer1で1秒ごとに処理
        private void timer1_Tick(object sender, EventArgs e)
        {
            //何回繰り返すかを読み取る　※のちに矢印画像から読み取れるように変更
            var count = int.Parse(max_count.Text);

            //現在の繰り返し回数のための変数の初期化
            var i = 1;

            //現在の繰り返し回数をcout_labelから受け取る
            i = int.Parse(cout_label.Text);

            if (i != count )
            {
                //描画先とするImageオブジェクトを作成する
                Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //ImageオブジェクトのGraphicsオブジェクトを作成する
                Graphics g = Graphics.FromImage(canvas);

                //画像ファイルを読み込んで、Imageオブジェクトとして取得する
                Image img = Image.FromFile(@".\Images\Player_Right.jpg");

                //画像ファイルが大きかったので、サイズを半分にしている
                var player_x = i * img.Width / 2;

                //画像をcanvasの座標(x, 10)の位置に描画する
                g.DrawImage(img, player_x, 10, img.Width / 2, img.Height / 2);
                //Imageオブジェクトのリソースを解放する
                img.Dispose();

                //Graphicsオブジェクトのリソースを解放する
                g.Dispose();
                //PictureBox1に表示する
                pictureBox1.Image = canvas;

                //繰り返し回数を増やす
                i++;

                //labelの更新
                cout_label.Text = i.ToString(); ;
            }
            //タイマーストップ
            else timer1.Enabled = false;       
        }
    }
}
