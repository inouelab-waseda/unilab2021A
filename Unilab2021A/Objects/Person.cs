using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unilab2021A.Helpers;
using System.Windows.Forms;
using static Unilab2021A.Helpers.Types;
using System.IO;
using System.Reflection;

namespace Unilab2021A.Objects
{
    class Person
    {
        //playerのx座標,y座標
        public int X { get;private set; }
        public int Y { get;private set; }
        //playerの向き
        public DirectionType Direction { get; set; }

        public int SwordCount { get; private set; }

        private Graphics Graphics { get; }
        private FlowLayoutPanel SwordSection { get; }
        private int StartX { get; }
        private int StartY { get; }
        private DirectionType StartDirectionType { get; }

        
        private Image[] images = new Image[4];

        public Person(Graphics graphics, FlowLayoutPanel swordSection, int x,int y,DirectionType direction)
        {
            Graphics = graphics;
            SwordSection = swordSection;

            images[(int)DirectionType.Up] = GetBitmap("Player_Up.png");//上の画像
            images[(int)DirectionType.Down] = GetBitmap("Player_Down.png");//下の画像
            images[(int)DirectionType.Right] = GetBitmap("Player_Right.png");//右の画像
            images[(int)DirectionType.Left] = GetBitmap("Player_Left.png");//左の画像

            X = x;
            Y = y;
            Direction = direction;

            StartX = x;
            StartY = y;
            StartDirectionType = direction;

            Draw();
        }

        //進行
        public void GoStraight()
        {
            switch (Direction)
            {
                case DirectionType.Up:
                    Y -= Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                    break;
                case DirectionType.Down:
                    Y += Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                    break;
                case DirectionType.Right:
                    X += Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                    break;
                case DirectionType.Left:
                    X -= Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                    break;
                default:
                    break;
            }

            Draw();
        }

        public void SetPersonDirection(ActionBlockType type)
        {
            switch (Direction)
            {
                case DirectionType.Up:
                    switch (type)
                    {
                        case ActionBlockType.TurnRight:
                            Direction = DirectionType.Right;
                            break;
                        case ActionBlockType.TurnLeft:
                            Direction = DirectionType.Left;
                            break;

                    }
                    break;
                case DirectionType.Right:
                    switch (type)
                    {
                        case ActionBlockType.TurnRight:
                            Direction = DirectionType.Down;
                            break;
                        case ActionBlockType.TurnLeft:
                            Direction = DirectionType.Up;
                            break;

                    }
                    break;
                case DirectionType.Down:
                    switch (type)
                    {
                        case ActionBlockType.TurnRight:
                            Direction = DirectionType.Left;
                            break;
                        case ActionBlockType.TurnLeft:
                            Direction = DirectionType.Right;
                            break;

                    }
                    break;
                case DirectionType.Left:
                    switch (type)
                    {
                        case ActionBlockType.TurnRight:
                            Direction = DirectionType.Up;
                            break;
                        case ActionBlockType.TurnLeft:
                            Direction = DirectionType.Down;
                            break;

                    }
                    break;
                default:
                    break;
            }

            Draw();
        }

        public void AddSword()
        {
            SwordCount++;

            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = GetBitmap("Sword.png");
            pictureBox.Width = Shares.BLOCK_CELL_SIZE;
            pictureBox.Height = Shares.BLOCK_CELL_SIZE;

            SwordSection.Controls.Add(pictureBox);

            Draw();
        }
        public void UseSword()
        {
            SwordCount--;

            int count = SwordSection.Controls.Count;
            SwordSection.Controls.Remove(SwordSection.Controls[count - 1]);

            Draw();
        }

        public void Reset()
        {

            X = StartX;
            Y = StartY;
            Direction = StartDirectionType;
            SwordCount = 0;
            SwordSection.Controls.Clear();

            Draw();
        }

        public void Draw()
        {
            Graphics.DrawImage(images[(int)Direction], X, Y, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
        }


        public Bitmap GetBitmap(string name)
        {
            /*
            入力:画像ファイル名
            対象画像を読み込む
            */
            Bitmap bmp = new Bitmap(@".\Images\" + name);
            return bmp;
        }
    }
}
