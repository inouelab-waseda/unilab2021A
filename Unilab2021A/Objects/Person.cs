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

        public int X { get; set; }
        public int Y { get; set; }
        public Types.Direction Direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
 
        //画像読込
        public Image[] images = new Image[4];
        public void Image_Install() 
        {
            images[0] = Image.FromFile(@".\Images\Player_Up.jpg");//上の画像
            images[1] = Image.FromFile(@".\Images\Player_Down.jpg");//下の画像
            images[2] = Image.FromFile(@".\Images\Player_Right.jpg");//右の画像
            images[3] = Image.FromFile(@".\Images\Player_Left.jpg");//左の画像
        }

        // { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public void DrawImage(Graphics g, Image images, int x, int y, int images_width, int images_height)
        {
            g.DrawImage(images, x, y, images_width, images_height);
        }
    }
}
