using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unilab2021A.Helpers;
using System.Windows.Forms;

namespace Unilab2021A.Objects
{
    class Person
    {
        private int x, y;
        private Graphics g;
        public Person()
        {
            X = 0;
            Y = 0;
        }
        //playerのx座標,y座標
        public int X { get; set; }
        public int Y { get; set; }
        //playerの移動回数
        public int count { get; set; }
        //playerの向き
        public int direction { get; set; }
        //public Types.Direction Direction{ get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Types.Direction Direction { get; set; } = Types.Direction.None;

        //画像読込
        public Image[] images = new Image[5];

        public void Image_Install() 
        {
            //images[(int)Types.Direction.None] = Image.FromFile(@".\Images\Player_None.jpg");
            images[(int)Types.Direction.Up] = Image.FromFile(@".\Images\Player_Up.jpg");//上の画像
            images[(int)Types.Direction.Down] = Image.FromFile(@".\Images\Player_Down.jpg");//下の画像
            images[(int)Types.Direction.Right] = Image.FromFile(@".\Images\Player_Right.jpg");//右の画像
            images[(int)Types.Direction.Left] = Image.FromFile(@".\Images\Player_Left.jpg");//左の画像
        }

        // { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //描画
        public void DrawImage(Graphics g, int num_Direction)
        {
            switch (num_Direction) 
            {
                /*case (int)Types.Direction.None:
                    g.DrawImage(images[(int)Types.Direction.None], X, Y, images[(int)Types.Direction.None].Width / 2, images[(int)Types.Direction.None].Height / 2);
                    break;*/
                case (int)Types.Direction.Up:
                    Y -= images[(int)Types.Direction.Up].Height / 2;
                    g.DrawImage(images[(int)Types.Direction.Up], X, Y, images[(int)Types.Direction.Up].Width / 2, images[(int)Types.Direction.Up].Height / 2);
                    break;
                case (int)Types.Direction.Down:
                    Y += images[(int)Types.Direction.Down].Height / 2;
                    g.DrawImage(images[(int)Types.Direction.Down], X, Y, images[(int)Types.Direction.Down].Width / 2, images[(int)Types.Direction.Down].Height / 2);
                    break;
                case (int)Types.Direction.Right:
                    X += images[(int)Types.Direction.Right].Width / 2;
                    g.DrawImage(images[(int)Types.Direction.Right], X, Y, images[(int)Types.Direction.Right].Width / 2, images[(int)Types.Direction.Right].Height / 2);
                    break;
                case (int)Types.Direction.Left:
                    X -= images[(int)Types.Direction.Left].Width / 2;
                    g.DrawImage(images[(int)Types.Direction.Left], X, Y, images[(int)Types.Direction.Left].Width / 2, images[(int)Types.Direction.Left].Height / 2);
                    break;
            }
        }
    }
}
