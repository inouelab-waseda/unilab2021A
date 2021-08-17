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
        private Bitmap stageCanvas;
        private Bitmap itemPictureBoxCanvas;
        private Graphics g;
        private Graphics itemPictureBoxGraphics;
        bool isDraging = false;
        Point? diffPoint = null;

        public GameForm()
        {
            InitializeComponent();

            //*6や*4は適当に調整する 04/12 笠井
            itemPictureBoxCanvas = new Bitmap(itemPictureBox.Width * 6, itemPictureBox.Height * 6);
            stageCanvas = new Bitmap(pictureBox1.Width*4, pictureBox1.Height*4);

            itemPictureBoxGraphics = Graphics.FromImage(itemPictureBoxCanvas);
            g = Graphics.FromImage(stageCanvas);

            person = new Person(g);
            stage = new Stage(g);

            //上下左右が分かりやすいように
            person.X_start = pictureBox1.Width / 3;
            person.Y_start = pictureBox1.Height / 3;
            person.X = person.X_start;
            person.Y = person.Y_start;

            DrawStart();

            stage.CreateStage();
            person.DrawImage(DirectionType.Down);
            stage.n_button = 3;//stage.csでjsonから受け取る
            Button[] buttons = new Button[stage.n_button];
            stage.button_content[0] = "↑";//ここもjsonで受け取れるといいかも
            stage.button_content[1] = "→";
            stage.button_content[2] = "F1";
            
            DrawEnd();

            for (int i = 0; i < stage.n_button; i++)
            {
                buttons[i] = new Button();
                buttons[i].Text = stage.button_content[i];
                buttons[i].Location = new Point(10, 30 * i);
                buttons[i].AllowDrop = true;
                buttons[i].MouseDown += new MouseEventHandler(buttons_MouseDown);
                buttons[i].MouseMove += new MouseEventHandler(buttons_MouseMove);
                buttons[i].MouseUp += new MouseEventHandler(buttons_MouseUp);
                panel1.Controls.Add(buttons[i]);
            }
        }

        private void DrawStart()
        {
            g.Clear(BackColor);
        }

        private void DrawEnd()
        {
            pictureBox1.Image = stageCanvas;
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
            if (comboBox1.Text == "上") person.Direction = DirectionType.Up;
            else if (comboBox1.Text == "下") person.Direction = DirectionType.Down;
            else if (comboBox1.Text == "右") person.Direction = DirectionType.Right;
            else if (comboBox1.Text == "左") person.Direction = DirectionType.Left;

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

        private void resetButton_Click(object sender, EventArgs e)
        {
            person.X = person.X_start;
            person.Y = person.Y_start;

            DrawStart();

            stage.CreateStage();
            person.DrawImage(DirectionType.Down);

            DrawEnd();
        }

        private void buttons_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Cursor.Current = Cursors.Hand;
            isDraging = true;
            diffPoint = e.Location;
        }
        
        private void buttons_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDraging)
            {
                return;
            }
            Button bt = (System.Windows.Forms.Button)sender;
            int x = bt.Location.X + e.X - diffPoint.Value.X;
            int y = bt.Location.Y + e.Y - diffPoint.Value.Y;

            bt.Location = new Point(x, y);
        }
        void buttons_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Cursor.Current = Cursors.Default;
            isDraging = false;
        }      
    }
}
