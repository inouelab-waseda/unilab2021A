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
        private Image[] images = new Image[5];
        //playerのx座標,y座標
        public int X { get; set; }
        public int Y { get; set; }
        //playerのx座標,y座標の初期位置
        public int X_start { get; set; }
        public int Y_start { get; set; }
        //playerの移動回数
        public int Count { get; set; }
        //playerの向き
        public DirectionType Direction { get; set; }

        public Graphics Graphics { get; set; }

        public Person(Graphics graphics)
        {
            this.Graphics = graphics;

            images[(int)DirectionType.Up] = GetBitmap("Player_Down.png");//上の画像
            images[(int)DirectionType.Down] = GetBitmap("Player_Down.png");//下の画像
            images[(int)DirectionType.Right] = GetBitmap("Player_Right.png");//右の画像
            images[(int)DirectionType.Left] = GetBitmap("Player_Left.png");//左の画像
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //描画
        public void DrawImage(DirectionType direction)
        {
            switch (direction) 
            {
                case DirectionType.Up:
                    Y -= images[(int)direction].Height / 2;
                    break;
                case DirectionType.Down:
                    Y += images[(int)direction].Height / 2;
                    break;
                case DirectionType.Right:
                    X += images[(int)direction].Width / 2;
                    break;
                case DirectionType.Left:
                    X -= images[(int)direction].Width / 2;
                    break;
                default:
                    break;
            }

            Graphics.DrawImage(images[(int)direction], X, Y, images[(int)direction].Width / 2, images[(int)direction].Height / 2);
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
