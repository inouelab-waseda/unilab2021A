using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unilab2021A.Fields;
using static Unilab2021A.Helpers.Types;

namespace Unilab2021A.Objects
{
    class Stage
    {
        public string StageName { get; set; }
        public Graphics Graphics { get; set; }
        public int n_button { get; set; }
        public string[] button_content = new string[10];

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
            StageJson json = ReadFieldJson("0");

            Image noneImage = Image.FromFile(@".\Images\Background.png");
            Image enemyImage = Image.FromFile(@".\Images\Enemy.png");

            for (int i = 0; i < json.Path.Count; i++)
            {
                if (json.Path[i].Image == ImageType.Others)
                {
                    //中島4/16 Graphicsが2904×2130で表現されているため、16×12に無理やり変えた,画像サイズでそれぞれ+1しているのは+1しないとintに変化しているため、微妙にサイズが小さくなりつなぎ目が出るから
                    //中島4/16 具体的な数字を使ったためうまく表現する方法があるかも
                    Graphics.DrawImage(noneImage, json.Path[i].Position[0] * 2904 / 16, json.Path[i].Position[1] * 2130 / 12, 2904 / 16 + 1, 2130 / 12 + 1);
                    //Graphics.DrawImage(noneImage, json.Path[i].Position[0] * 100, json.Path[i].Position[1] * 100, noneImage.Width , noneImage.Height );
                }
                else if (json.Path[i].Image == ImageType.Enemy)
                {
                    Graphics.DrawImage(enemyImage, json.Path[i].Position[0] * 2904 / 16, json.Path[i].Position[1] * 2130 / 12, 2904 / 16 + 1, 2130 / 12 + 1);
                    //Graphics.DrawImage(enemyImage, json.Path[i].Position[0] * 100, json.Path[i].Position[1] * 100, enemyImage.Width / 2, enemyImage.Height / 2);
                }
            }

        }

        //jsonファイルの読み出し
        private StageJson ReadFieldJson(string name)
        {
            var sr = new StreamReader(@".\Fields\" + name + ".json",Encoding.GetEncoding("utf-8"));
            var input = sr.ReadToEnd();
            sr.Close();
            var deserialized = JsonConvert.DeserializeObject<StageJson>(input);
            return deserialized;
        }       
    }
}
