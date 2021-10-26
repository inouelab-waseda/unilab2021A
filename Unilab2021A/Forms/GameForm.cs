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
        public string stageName;

        public GameForm(string stageName)
        {
            InitializeComponent();

            this.stageName = stageName;

            //*6や*4は適当に調整する 04/12 笠井
            stageCanvas = new Bitmap(pictureBox1.Width * 4, pictureBox1.Height * 4);

            g = Graphics.FromImage(stageCanvas);

            DrawStart();

            stage = new Stage(g, ActionBlockTypeSection, FirstFunctionSection, SecondFunctionSection, block_MouseDown, stageName);
            person = new Person(g, SwordSection, stage.StartPosition_X, stage.StartPosition_Y, DirectionType.Right);

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

        private void startButton_Click(object sender, EventArgs e)
        {
            //timerをスタート
            if(!timer1.Enabled && !timer2.Enabled)
            {
                timer1.Enabled = true;
                firstStep = 0;
                secondStep = 0;
            }
        }

        //関数1を1秒ごとに処理
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (firstStep < stage.FirstActions.Length)
            {
                DrawStart();          
                stage.DrawPath();

                //状態ブロック
                if (stage.CanAct(stage.FirstActions[firstStep],stage.FirstConditions[firstStep], person.X, person.Y))
                {
                    //方向転換ブロック
                    if (stage.FirstActions[firstStep] == ActionBlockType.TurnLeft || stage.FirstActions[firstStep] == ActionBlockType.TurnRight)
                    {
                        person.SetPersonDirection(stage.FirstActions[firstStep]);
                        firstStep++;
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

                        firstStep++;
                    }
                    //関数1ブロック
                    else if (stage.FirstActions[firstStep] == ActionBlockType.First)
                    {
                        firstStep = 0;
                        person.Draw();
                    }
                    //関数2ブロック
                    else if (stage.FirstActions[firstStep] == ActionBlockType.Second)
                    {
                        secondStep = 0;
                        timer1.Enabled = false;
                        timer2.Enabled = true;
                        person.Draw();
                    }
                }
                else
                {
                    person.Draw();
                    firstStep++;
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

                // クリア判定
                if (!stage.IsEnemyRemained())
                {
                    timer1.Enabled = false;
                    PopUp popUp = new PopUp(this);
                    popUp.ShowDialog();
                }
            }
            //関数2から関数1を呼び出され、関数1の実行が終わったとき、関数2の続きを実行
            else if (secondStep < stage.SecondActions.Length && stage.SecondActions[secondStep] == ActionBlockType.First)
            {
                //次のステップに進めておく
                secondStep++;
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
            //タイマーストップ
            else 
            {
                timer1.Enabled = false;              

                if (stage.IsEnemyRemained())
                {
                    // 失敗
                    resetGame();
                }
            }
        }

        //関数2を1秒ごとに処理
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (secondStep < stage.SecondActions.Length)
            {
                DrawStart();
                stage.DrawPath();

                //状態ブロック
                if (stage.CanAct(stage.SecondActions[secondStep], stage.SecondConditions[secondStep], person.X, person.Y))
                {
                    //方向転換ブロック
                    if (stage.SecondActions[secondStep] == ActionBlockType.TurnLeft || stage.SecondActions[secondStep] == ActionBlockType.TurnRight)
                    {
                        person.SetPersonDirection(stage.SecondActions[secondStep]);
                        secondStep++;
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

                        secondStep++;
                    }
                    //関数1ブロック
                    else if (stage.SecondActions[secondStep] == ActionBlockType.First)
                    {
                        firstStep = 0;
                        secondStep++;
                        timer1.Enabled = true;
                        timer2.Enabled = false;
                    }
                    //関数2ブロック
                    else if (stage.SecondActions[secondStep] == ActionBlockType.Second)
                    {
                        secondStep = 0;
                    }
                }
                else
                {
                    person.Draw();
                    secondStep++;
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

                // クリア判定
                if (!stage.IsEnemyRemained())
                {
                    timer2.Enabled = false;
                    PopUp popUp = new PopUp(this);
                    popUp.ShowDialog();
                }
            }
            //関数1から関数2を呼び出され、関数2の実行が終わったとき、関数1の続きを実行
            else if (firstStep < stage.FirstActions.Length && stage.FirstActions[firstStep] == ActionBlockType.Second)
            {
                //次のステップに進めておく
                firstStep++;
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
            //タイマーストップ
            else
            {
                timer2.Enabled = false;

                if (stage.IsEnemyRemained())
                {
                    // 失敗
                    resetGame();
                }
            }
        }

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

        private void block_MouseDown(object sender, MouseEventArgs e) =>
            DoDragDrop(stage.TransformNameIntoBlockType(((PictureBox)sender).Name), DragDropEffects.All);
    }
}
