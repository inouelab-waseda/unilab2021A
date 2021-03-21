using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unilab2021A.Fields;
using Unilab2021A.Forms;

namespace Unilab2021A.Objects
{
    class Stage
    {
        public string StageName { get; set; }
        public Button[] ActionButtons { get; set; }
        private Field field;

        public Stage()
        {
            // 仮に設定
            StageName = "0";
        }

        public void CreateStage(Graphics g)
        {
            // jsonファイルの読み込みなど(StageName)
            // --------
            field = ReadFieldJson(StageName);
            for (int i = 0; i < field.Actions.Count; i++){
                Console.WriteLine(field.Actions[i].Type);
            }
            

            Image ObjImage = Image.FromFile(@".\Images\Player_Left.jpg");     //仮の画像
            this.Draw(g, ObjImage, ObjImage.Width * 2, 0, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(g, ObjImage, ObjImage.Width * 2, ObjImage.Height / 2, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(g, ObjImage, ObjImage.Width * 2, ObjImage.Height, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(g, ObjImage, ObjImage.Width * 2, ObjImage.Height * 3 / 2, ObjImage.Width / 2, ObjImage.Height / 2);
            this.Draw(g, ObjImage, ObjImage.Width * 2, ObjImage.Height * 2, ObjImage.Width / 2, ObjImage.Height / 2);

            string[] types = { "Left", "Right" };
            //CreateButton(types);
        }

        public void Draw(Graphics g, Image image, int x, int y, int images_width, int images_height)
        {
            g.DrawImage(image, x, y, images_width, images_height);
        }

        private void CreateButton(string[] types)
        {
            //Buttonクラスのインスタンスを作成する
            this.ActionButtons = new Button[types.Length];

            for (int i = 0; i < ActionButtons.Length; i++)
            {
                this.ActionButtons[i] = new Button();

                //Buttonコントロールのプロパティを設定する
                this.ActionButtons[i].Name = types[i];
                this.ActionButtons[i].Text = types[i];
                //サイズと位置を設定する
                this.ActionButtons[i].Location = new Point(1000 + 100 * i, 450);
                this.ActionButtons[i].Size = new Size(100, 50);

                //フォームに追加する？できない - GameFormのインスタンスが欲しい?
                // GameForm.Controls.Add(this.ActionButtons[i]);
            }
        }

        private Field ReadFieldJson(string name)
        {
            //現在のコードを実行しているAssemblyを取得
            var myAssembly = Assembly.GetExecutingAssembly();
            var sr = new StreamReader(
                myAssembly.GetManifestResourceStream("Unilab2021A.Fields." + name + ".json"),
                    Encoding.GetEncoding("utf-8"));
            var input = sr.ReadToEnd();
            sr.Close();

            var deserialized = JsonConvert.DeserializeObject<Field>(
                input, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            return deserialized;
        }
    }
}
