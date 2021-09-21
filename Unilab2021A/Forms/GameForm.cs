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
        private Graphics g;
        //ステップの進んだ数
        private int firstStep;
        //ボタンの矢印を受け取る変数
        DirectionType block_direction;

        public GameForm()
        {
            InitializeComponent();

            //*6や*4は適当に調整する 04/12 笠井
            stageCanvas = new Bitmap(pictureBox1.Width * 4, pictureBox1.Height * 4);

            g = Graphics.FromImage(stageCanvas);

            DrawStart();

            person = new Person(g);
            stage = new Stage(g, ActionBlockTypeSection, FirstFunctionSection,SecondFunctionSection, button_MouseDown);

            //上下左右が分かりやすいように
            person.X_start = stage.StartPosition_X;
            person.Y_start = stage.StartPosition_Y;
            person.X = person.X_start;
            person.Y = person.Y_start;
            person.Direction = DirectionType.Right;

            person.DrawImage(person.Direction);

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
            firstStep = 0;
        }

        //描画をtimer1で1秒ごとに処理
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (firstStep < stage.FirstFunction.Count)
            {
                DrawStart();
                stage.CreatePath();

                //person.Direction = stage.getDirection(stage.FirstFunction[firstStep]);


                block_direction = stage.getDirection(stage.FirstFunction[firstStep]);
                bool isRoad = stage.IsRoad(person.Direction, person.X, person.Y);

                if (isRoad)
                {
                    if (block_direction == DirectionType.Up)
                    {
                        if (person.Direction == DirectionType.Up)
                        {
                            person.DrawImage(person.Direction);

                        }
                        else if (person.Direction == DirectionType.Down)
                        {
                            person.DrawImage(person.Direction);
                        }
                        else if (person.Direction == DirectionType.Left)
                        {
                            person.DrawImage(person.Direction);
                        }
                        else if (person.Direction == DirectionType.Right)
                        {
                            person.DrawImage(person.Direction);
                        }                       
                    }
                    else if (block_direction == DirectionType.Right)
                    {
                        if (person.Direction == DirectionType.Up)
                        {                          
                            person.Direction = DirectionType.Right;
                            person.X -= Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                            person.DrawImage(person.Direction);
                        }
                        else if (person.Direction == DirectionType.Down)
                        {
                            person.Direction = DirectionType.Left;
                            person.X += Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                            person.DrawImage(person.Direction);
                        }
                        else if (person.Direction == DirectionType.Left)
                        {
                            person.Direction = DirectionType.Up;
                            person.Y += Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                            person.DrawImage(person.Direction);
                        }
                        else if (person.Direction == DirectionType.Right)
                        {
                            person.Direction = DirectionType.Down;
                            person.Y -= Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                            person.DrawImage(person.Direction);
                        }
                    }
                    else if (block_direction == DirectionType.Left)
                    {
                        if (person.Direction == DirectionType.Up)
                        {
                            person.Direction = DirectionType.Left;
                            person.X += Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                            person.DrawImage(person.Direction);
                        }
                        else if (person.Direction == DirectionType.Down)
                        {
                            person.Direction = DirectionType.Right;
                            person.X -= Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                            person.DrawImage(person.Direction);
                        }
                        else if (person.Direction == DirectionType.Left)
                        {
                            person.Direction = DirectionType.Down;
                            person.Y -= Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                            person.DrawImage(person.Direction);
                        }
                        else if (person.Direction == DirectionType.Right)
                        {
                            person.Direction = DirectionType.Up;
                            person.Y += Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                            person.DrawImage(person.Direction);
                        }
                    }
                }
                else
                {
                    if (person.Direction == DirectionType.Up)
                    {
                        person.Y += Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                        person.DrawImage(person.Direction);
                    }
                    else if (person.Direction == DirectionType.Down)
                    {
                        person.Y -= Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                        person.DrawImage(person.Direction);
                    }
                    else if (person.Direction == DirectionType.Left)
                    {
                        person.X += Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                        person.DrawImage(person.Direction);
                    }
                    else if (person.Direction == DirectionType.Right)
                    {
                        person.X -= Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                        person.DrawImage(person.Direction);
                    }
                }

                DrawEnd();
                firstStep++;
            }
            //タイマーストップ
            //クリアできたか判定の処理を入れる？(笠井)
            else timer1.Enabled = false; 

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            person.X = person.X_start;
            person.Y = person.Y_start;

            DrawStart();

            stage.Reset();
            person.Direction = DirectionType.Right;
            person.DrawImage(person.Direction);

            DrawEnd();
        }

        // Initiate the drag
        private void button_MouseDown(object sender, MouseEventArgs e) =>
            DoDragDrop(((Button)sender).Text, DragDropEffects.All);
    }
}
