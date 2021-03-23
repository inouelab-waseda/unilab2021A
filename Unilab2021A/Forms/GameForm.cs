using System;
using System.Drawing;
using System.Windows.Forms;
using Unilab2021A.Objects;
using Unilab2021A.Helpers;

//完成に向けてすること------------------------------------------------------------------------
//max_countはtextboxで、何回繰り返すかを書く→あとからこれを矢印の画像に対応するように変更
//count_labelは、繰り返し回数の計測→あとから工夫して消去したい
//----------------------------------------------------------------------------------------------

namespace Unilab2021A.Forms
{
    public partial class GameForm : Form
    {
        Person person;
        Stage stage;
        private Graphics g;

        public GameForm()
        {
            InitializeComponent();
            person = new Person();
            stage = new Stage();
            //画像読込の開始
            person.Image_Install();

            //上下左右が分かりやすいように
            person.X = pictureBox1.Width / 3;
            person.Y = pictureBox1.Height / 3;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //画像をcanvasの座標(person.X, person.Y)の位置に描画する
            person.DrawImage(g, (int)Types.Direction.Down);

            stage.CreateStage(g);

            //PictureBox1に表示する
            pictureBox1.Image = canvas;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //リセット用(消す予定)
            person.X = pictureBox1.Width / 3;
            person.Y = pictureBox1.Height / 3;

            //画像をcanvasの座標(person.X, person.Y)の位置に描画する
            person.DrawImage(g, (int)Types.Direction.Down);

            //PictureBox1に表示する
            pictureBox1.Image = canvas;

            person.count = 0;

            stage.CreateStage(g);

            //timerをスタート
            timer1.Enabled = true;

        }

        //描画をtimer1で1秒ごとに処理
        private void timer1_Tick(object sender, EventArgs e)
        {
            //何回繰り返すかを読み取る　※のちに矢印画像から読み取れるように変更
            var count = int.Parse(max_count.Text);

            //上下左右判定
            if (comboBox1.Text == "上") person.direction = (int)Types.Direction.Up;
            else if (comboBox1.Text == "下") person.direction = (int)Types.Direction.Down;
            else if (comboBox1.Text == "右") person.direction = (int)Types.Direction.Right;
            else if (comboBox1.Text == "左") person.direction = (int)Types.Direction.Left;

            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            if (person.count != count )
            {
                stage.CreateStage(g);

                //画像をcanvasの座標(person.X, person.Y)の位置に描画する
                person.DrawImage(g, person.direction);

                //PictureBox1に表示する
                pictureBox1.Image = canvas;

                //繰り返し回数を増やす
                person.count++;
            }
            //タイマーストップ
            else timer1.Enabled = false;       
        }
    }
}
