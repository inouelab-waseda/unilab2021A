using System;
using System.Drawing;
using System.Windows.Forms;
using Unilab2021A.Objects;
using Unilab2021A.Helpers;
using static Unilab2021A.Helpers.Types;

//完成に向けてすること------------------------------------------------------------------------
//max_countはtextboxで、何回繰り返すかを書く→あとからこれを矢印の画像に対応するように変更
//count_labelは、繰り返し回数の計測→あとから工夫して消去したい
//----------------------------------------------------------------------------------------------

namespace Unilab2021A.Forms
{
    public partial class GameForm : Form
    {
        private Person person;
        private Stage stage;
        private Bitmap canvas;
        private Bitmap itemPictureBoxCanvas;
        private Bitmap actionPictureBoxCanvas;
        private Graphics g;
        private Graphics itemPictureBoxGraphics;
        private Graphics actionPictureBoxGraphics;
        //private Field _field;

        public GameForm()
        {
            InitializeComponent();

            itemPictureBoxCanvas = new Bitmap(itemPictureBox.Width * 6, itemPictureBox.Height * 6);
            actionPictureBoxCanvas = new Bitmap(actionPictureBox.Width * 6, actionPictureBox.Height * 6);
            canvas = new Bitmap(pictureBox1.Width*4, pictureBox1.Height*4);

            itemPictureBoxGraphics = Graphics.FromImage(itemPictureBoxCanvas);
            actionPictureBoxGraphics = Graphics.FromImage(actionPictureBoxCanvas);
            g = Graphics.FromImage(canvas);

            person = new Person(g);
            stage = new Stage(g);

            //上下左右が分かりやすいように
            person.X = pictureBox1.Width / 3;
            person.Y = pictureBox1.Height / 3;

            DrawStart();

            stage.CreateStage();
            person.DrawImage(Direction.Down);

            DrawEnd();
        }

        private void DrawStart()
        {
            g.Clear(BackColor);
        }

        private void DrawEnd()
        {
            pictureBox1.Image = canvas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timerをスタート
            timer1.Enabled = true;
            person.Count = 0;
        }

        //描画をtimer1で1秒ごとに処理
        private void timer1_Tick(object sender, EventArgs e)
        {

            //何回繰り返すかを読み取る　※のちに矢印画像から読み取れるように変更
            var count = int.Parse(max_count.Text);

            //上下左右判定
            if (comboBox1.Text == "上") person.Direction = Direction.Up;
            else if (comboBox1.Text == "下") person.Direction = Direction.Down;
            else if (comboBox1.Text == "右") person.Direction = Direction.Right;
            else if (comboBox1.Text == "左") person.Direction = Direction.Left;

            if (person.Count != count )
            {
                DrawStart();
                stage.CreateStage();

                //画像をcanvasの座標(person.X, person.Y)の位置に描画する
                person.DrawImage(person.Direction);

                //繰り返し回数を増やす
                person.Count++;

                DrawEnd();
            }
            //タイマーストップ
            else timer1.Enabled = false;
 
        }
    }
}
