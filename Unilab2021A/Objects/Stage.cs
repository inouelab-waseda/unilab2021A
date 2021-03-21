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

        public Stage()
        {
            // 仮に設定
            StageName = "stage1";
        }

        public void CreateStage(Graphics g)
        {
            // jsonファイルの読み込みなど(StageName)
            // --------


            Image ObjImage = Image.FromFile(@".\Images\Player_Left.jpg");     //仮の画像
            this.Draw(g, ObjImage, ObjImage.Width * 2, 0, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(g, ObjImage, ObjImage.Width * 2, ObjImage.Height / 2, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(g, ObjImage, ObjImage.Width * 2, ObjImage.Height, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(g, ObjImage, ObjImage.Width * 2, ObjImage.Height * 3 / 2, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(g, ObjImage, ObjImage.Width * 2, ObjImage.Height * 2, ObjImage.Width / 2, ObjImage.Height / 2);
        }

        public void Draw(Graphics g, Image image, int x, int y, int images_width, int images_height)
        {
            g.DrawImage(image, x, y, images_width, images_height);
        }
    }
}
