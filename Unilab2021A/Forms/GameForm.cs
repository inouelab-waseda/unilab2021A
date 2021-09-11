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

        public GameForm()
        {
            InitializeComponent();

            //*6や*4は適当に調整する 04/12 笠井
            itemPictureBoxCanvas = new Bitmap(itemPictureBox.Width * 6, itemPictureBox.Height * 6);
            stageCanvas = new Bitmap(pictureBox1.Width * 4, pictureBox1.Height * 4);

            itemPictureBoxGraphics = Graphics.FromImage(itemPictureBoxCanvas);
            g = Graphics.FromImage(stageCanvas);

            DrawStart();

            person = new Person(g);
            stage = new Stage(g, ActionBlockTypeSection,MainActionSection, button_MouseDown);

            //上下左右が分かりやすいように
            person.X_start = stage.StartPosition_X;
            person.Y_start = stage.StartPosition_Y;
            person.X = person.X_start;
            person.Y = person.Y_start;

            person.DrawImage(DirectionType.Down);

            DrawEnd();
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
            var count = 10;//int.Parse(max_count.Text);

            ////上下左右判定
            //if (textBox3.Text == "↑") person.Direction = DirectionType.Up;
            //else if (textBox3.Text == "↓") person.Direction = DirectionType.Down;
            //else if (textBox3.Text == "→") person.Direction = DirectionType.Right;
            //else if (textBox3.Text == "←") person.Direction = DirectionType.Left;

            if (person.Count != count)
            {
                DrawStart();
                stage.CreatePath();

                if (person.Direction == DirectionType.Up)
                {
                    if (stage.canMove[person.X / (2904 / 16), person.Y / (2130 / 12) - 1] == true)//先が道の時
                    {
                        person.DrawImage(person.Direction);//画像をcanvasの座標(person.X, person.Y)の位置に描画する
                    }
                    else//先が草の時
                    {
                        person.Y += 2130 / 12;
                        person.DrawImage(person.Direction);
                    }
                }
                else if (person.Direction == DirectionType.Down)
                {
                    if (stage.canMove[person.X / (2904 / 16), person.Y / (2130 / 12) + 1] == true)//先が道の時
                    {
                        person.DrawImage(person.Direction);//画像をcanvasの座標(person.X, person.Y)の位置に描画する
                    }
                    else//先が草の時
                    {
                        person.Y -= 2130 / 12;
                        person.DrawImage(person.Direction);
                    }
                }
                else if (person.Direction == DirectionType.Left)
                {
                    if (stage.canMove[person.X / (2904 / 16) - 1, person.Y / (2130 / 12)] == true)//先が道の時
                    {
                        person.DrawImage(person.Direction);//画像をcanvasの座標(person.X, person.Y)の位置に描画する
                    }
                    else//先が草の時
                    {
                        person.X += 2904 / 16;
                        person.DrawImage(person.Direction);
                    }
                }
                else if (person.Direction == DirectionType.Right)
                {
                    if (stage.canMove[person.X / (2904 / 16) + 1, person.Y / (2130 / 12)] == true)//先が道の時
                    {
                        person.DrawImage(person.Direction);//画像をcanvasの座標(person.X, person.Y)の位置に描画する
                    }
                    else//先が草の時
                    {
                        person.X -= 2904 / 16;
                        person.DrawImage(person.Direction);
                    }
                }

                /*if (stage.flag[person.X / (2904 / 16), person.Y / (2130 / 12)] == true) 
                {
                    person.DrawImage(person.Direction);//画像をcanvasの座標(person.X, person.Y)の位置に描画する
                } */
                /*else
                {
                    if (person.Direction == DirectionType.Up) person.Y += 2130 / 12;
                    else if (person.Direction == DirectionType.Down) person.Y -= 2130 / 12;
                    else if (person.Direction == DirectionType.Left) person.X += 2904 / 16;
                    else if (person.Direction == DirectionType.Right) person.X -= 2904 / 16;
                    person.DrawImage(person.Direction);
                }*/


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

            stage = new Stage(g, ActionBlockTypeSection,MainActionSection, button_MouseDown);
            person.DrawImage(DirectionType.Down);

            DrawEnd();
        }

        // Initiate the drag
        private void button_MouseDown(object sender, MouseEventArgs e) =>
            DoDragDrop(((Button)sender).Text, DragDropEffects.All);
    }
}
