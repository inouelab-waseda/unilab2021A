using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unilab2021A.Objects
{
    class Stage
    {
        public string StageName { get; set; }
        public Graphics Graphics { get; set; }

        public Stage(Graphics graphics)
        {
            // 仮に設定
            StageName = "stage1";

            Graphics = graphics;
        }

        public void CreateStage()
        {
            // jsonファイルの読み込みなど(StageName)
            // --------


            Image ObjImage = Image.FromFile(@".\Images\Enemy.png");     //仮の画像
            this.Draw(Graphics, ObjImage, ObjImage.Width * 2, 0, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(Graphics, ObjImage, ObjImage.Width * 2, ObjImage.Height / 2, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(Graphics, ObjImage, ObjImage.Width * 2, ObjImage.Height, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(Graphics, ObjImage, ObjImage.Width * 2, ObjImage.Height * 3 / 2, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(Graphics, ObjImage, ObjImage.Width * 2, ObjImage.Height * 2, ObjImage.Width / 2, ObjImage.Height / 2);
        }

        private void Draw(Graphics g, Image image, int x, int y, int images_width, int images_height)
        {
            g.DrawImage(image, x, y, images_width, images_height);
        }
    }
}
