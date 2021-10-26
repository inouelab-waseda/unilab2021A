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
        
        public void _initialize(String stageName)
        {

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

                DrawEnd();
                firstStep++;

                if (firstStep < stage.FirstActions.Count)
                {
                    if (stage.FirstActions[firstStep] == ActionBlockType.First)
                    {
                        person.Draw();
                        firstStep = 0;
                    }
                }
                if (firstStep < stage.FirstActions.Count)
                {           
                    if (stage.FirstActions[firstStep] == ActionBlockType.Second)
                    {
                        person.Draw();
                        secondStep = 0;
                        //timerをスタート
                        timer2.Enabled = true;
                        
                    }              
                }
                person.Draw();

                // クリア判定
                if (!stage.IsEnemyRemained())
                {
                    timer1.Enabled = false;
                    PopUp popUp = new PopUp(this);
                    popUp.ShowDialog();
                }
            }
            //タイマーストップ
            else 
            {
                timer1.Enabled = false;              

                if (stage.IsEnemyRemained())
                {
                    // 失敗
                    GameOver gameOver = new GameOver(this);
                    gameOver.ShowDialog();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            secondStep = 0;
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

                if (secondStep < stage.SecondActions.Count)
                {
                    if (stage.SecondActions[secondStep] == ActionBlockType.First)
                    {
                        firstStep = 0;
                    }
                }
                if (secondStep < stage.SecondActions.Count)
                {
                    if (stage.SecondActions[secondStep] == ActionBlockType.Second)
                    {
                        timer2.Enabled = false;
                        secondStep = 0;
                        //timerをスタート
                        timer2.Enabled = true;
                        
                    }
                }
            }
            //タイマーストップ
            else
            {
                timer2.Enabled = false;
                
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
