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
        private int secondStep;
        private int flag_F1 = 0;//F1が存在するかどうかの判定
        private int flag_F2 = 0;//F2が存在するかどうかの判定


        public GameForm()
        {
            InitializeComponent();

            //*6や*4は適当に調整する 04/12 笠井
            stageCanvas = new Bitmap(pictureBox1.Width * 4, pictureBox1.Height * 4);

            g = Graphics.FromImage(stageCanvas);

            DrawStart();

            stage = new Stage(g, ActionBlockTypeSection, FirstFunctionSection,SecondFunctionSection, actionBlock_MouseDown,conditionBlock_MouseDown);
            person = new Person(g, SwordSection, stage.StartPosition_X,stage.StartPosition_Y, DirectionType.Right);

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
            if (firstStep < stage.FirstActions.Count)
            {
                DrawStart();
                stage.DrawPath();

                //状態ブロック
                if (stage.CanAct(stage.FirstConditions[firstStep], person.X, person.Y))
                {
                    //方向転換ブロック
                    if (stage.FirstActions[firstStep] == ActionBlockType.TurnLeft || stage.FirstActions[firstStep] == ActionBlockType.TurnRight)
                    {
                        person.SetPersonDirection(stage.FirstActions[firstStep]);
                    }
                    //進行ブロック
                    else if (stage.FirstActions[firstStep] == ActionBlockType.GoStraight)
                    {
                        bool isRoad = stage.IsRoad(person.Direction, person.X, person.Y);
                        if (isRoad)
                        {
                            person.GoStraight();
                        }
                        else
                        {
                            person.Draw();
                        }

                    }
                }
                else
                {
                    person.Draw();
                }

                if (stage.IsSword(person.X, person.Y))
                {
                    person.AddSword();
                }

                if (stage.IsEnemy(person.SwordCount, person.X, person.Y))
                {
                    person.UseSword();
                }

                /*if (stage.FirstActions[firstStep] == ActionBlockType.First)
                {
                    firstStep = -1;
                    person.Draw();
                }*/

                DrawEnd();
                firstStep++;


                for (int i = 0; i < stage.FirstActions.Count; i++)
                {
                    if (stage.FirstActions[i] == ActionBlockType.First) flag_F1 = 1;
                }
                if (flag_F1 == 1)
                {
                    if (stage.FirstActions[firstStep] == ActionBlockType.First)
                    {
                        firstStep = 0;
                    }
                }

                for (int i = 0; i < stage.FirstActions.Count; i++)
                {
                    if (stage.FirstActions[i] == ActionBlockType.Second) flag_F2 = 1;
                }
                if (firstStep < stage.FirstActions.Count && flag_F2 == 1)
                {
                    person.Draw();
                    if (stage.FirstActions[firstStep] == ActionBlockType.Second)
                    {
                        //timerをスタート
                        timer2.Enabled = true;
                        secondStep = 0;                 
                    }
                }
            }
            //タイマーストップ
            else
            {
                timer1.Enabled = false;

                if (stage.IsEnemyRemained())
                {
                    // 失敗
                    resetGame();
                    flag_F1 = 0;
                    flag_F2 = 0;
                }
                else
                {
                    // クリア
                }


            }

        }

        //
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (secondStep < stage.SecondActions.Count)
            {
                DrawStart();
                stage.DrawPath();

                //状態ブロック
                if (stage.CanAct(stage.SecondConditions[secondStep], person.X, person.Y))
                {
                    //方向転換ブロック
                    if (stage.SecondActions[secondStep] == ActionBlockType.TurnLeft || stage.SecondActions[secondStep] == ActionBlockType.TurnRight)
                    {
                        person.SetPersonDirection(stage.SecondActions[secondStep]);
                    }
                    //進行ブロック
                    else if (stage.SecondActions[secondStep] == ActionBlockType.GoStraight)
                    {
                        bool isRoad = stage.IsRoad(person.Direction, person.X, person.Y);
                        if (isRoad)
                        {
                            person.GoStraight();
                        }
                        else
                        {
                            person.Draw();
                        }

                    }
                }
                else
                {
                    person.Draw();
                }

                if (stage.IsSword(person.X, person.Y))
                {
                    person.AddSword();
                }

                if (stage.IsEnemy(person.SwordCount, person.X, person.Y))
                {
                    person.UseSword();
                }

                DrawEnd();
                secondStep++;

                for (int i = 0; i < stage.SecondActions.Count; i++)
                {
                    if (stage.SecondActions[i] == ActionBlockType.First) flag_F1 = 1;
                }
                if (flag_F1 == 1)
                {
                    if (stage.SecondActions[secondStep] == ActionBlockType.First)
                    {
                        firstStep = 0;
                        person.Draw();
                    }
                }

                for (int i = 0; i < stage.SecondActions.Count; i++)
                {
                    if (stage.SecondActions[i] == ActionBlockType.Second) flag_F2 = 1;
                }
                if (flag_F2 == 1)
                {
                    if (stage.SecondActions[secondStep] == ActionBlockType.Second)
                    {
                        secondStep = 0;
                        person.Draw();
                    }
                }
            }
            //タイマーストップ
            else
            {
                timer2.Enabled = false;
            }

        }
        //

        private void resetGame()
        {
            DrawStart();

            stage.Reset();
            person.Reset();

            DrawEnd();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        private void conditionBlock_MouseDown(object sender, MouseEventArgs e) =>
            DoDragDrop(((Button)sender).BackColor, DragDropEffects.All);
        private void actionBlock_MouseDown(object sender, MouseEventArgs e) =>
            DoDragDrop(((Button)sender).Text, DragDropEffects.All);


    }
}
