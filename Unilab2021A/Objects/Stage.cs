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
using static Unilab2021A.Helpers.Types;

namespace Unilab2021A.Objects
{
    class Stage
    {

        public bool[,] canMove = new bool[16, 12];//道か草かの判定
        public int StartPosition_X { get; set; }
        public int StartPosition_Y { get; set; }
        public ActionBlockType[] mainActions { get; set; }

        private StageJson json;
        private Graphics Graphics { get; set; }
        private FlowLayoutPanel ActionBlockTypeSection { get; set; }
        private FlowLayoutPanel MainActionSection { get; set; }
        private Action<object, MouseEventArgs> ActionBlock_MouseDown { get; set; }

        // 定数
        private const int WIDTH = 2904;
        private const int HEIGHT = 2130;
        private const int WIDTH_CELL_NUM = 16;
        private const int HEIGHT_CELL_NUM = 12;
        private const int ACTION_BLOCK_TYPE_SIZE = 30;

        public Stage(Graphics graphics, FlowLayoutPanel actionBlockTypeSection, FlowLayoutPanel mainActionSection, Action<object, MouseEventArgs> actionBlock_MouseDown)
        {
            Graphics = graphics;
            ActionBlockTypeSection = actionBlockTypeSection;
            ActionBlock_MouseDown = actionBlock_MouseDown;
            MainActionSection = mainActionSection;

            // jsonファイルの読み込みなど(StageName)
            // --------
            json = ReadFieldJson("1_1");

            //道の作成
            CreatePath();

            //アクションブロックの作成
            CreateActionBlockTypeSection();

            //アクションブロックの受取先の作成
            CreateReceivingActionBlockSection();

            //初期位置の座標
            StartPosition_X = json.StartPosition[0] * WIDTH / WIDTH_CELL_NUM;
            StartPosition_Y = (json.StartPosition[1] - 1) * HEIGHT / HEIGHT_CELL_NUM;
        }

        public void CreatePath()
        {
            Image noneImage = Image.FromFile(@".\Images\Background.png");
            Image enemyImage = Image.FromFile(@".\Images\Enemy.png");

            //flagの初期化
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    canMove[i, j] = true;
                }
            }

            //道の作成
            for (int i = 0; i < json.Path.Count; i++)
            {
                if (json.Path[i].Image == ImageType.Others)
                {
                    //中島4/16 GraphicsがWIDTH×HEIGHTで表現されているため、WIDTH_CELL_NUM×HEIGHT_CELL_NUMに無理やり変えた,画像サイズでそれぞれ+1しているのは+1しないとintに変化しているため、微妙にサイズが小さくなりつなぎ目が出るから
                    //中島4/16 具体的な数字を使ったためうまく表現する方法があるかも
                    Graphics.DrawImage(noneImage, json.Path[i].Position[0] * WIDTH / WIDTH_CELL_NUM, json.Path[i].Position[1] * HEIGHT / HEIGHT_CELL_NUM, WIDTH / WIDTH_CELL_NUM + 1, HEIGHT / HEIGHT_CELL_NUM + 1);
                    canMove[json.Path[i].Position[0], json.Path[i].Position[1]] = false;//草はfalseに
                }
                else if (json.Path[i].Image == ImageType.Enemy)
                {
                    Graphics.DrawImage(enemyImage, json.Path[i].Position[0] * WIDTH / WIDTH_CELL_NUM, json.Path[i].Position[1] * HEIGHT / HEIGHT_CELL_NUM, WIDTH / WIDTH_CELL_NUM + 1, HEIGHT / HEIGHT_CELL_NUM + 1);
                }
            }
        }

        public void CreateActionBlockTypeSection()
        {
            Button[] buttons = new Button[json.ActionBlockTypes.Count];

            for (int i = 0; i < json.ActionBlockTypes.Count; i++)
            {
                buttons[i] = new Button();
                buttons[i].Width = ACTION_BLOCK_TYPE_SIZE;
                buttons[i].Height = ACTION_BLOCK_TYPE_SIZE;
                switch (json.ActionBlockTypes[i])
                {
                    case ActionBlockType.Up:
                        buttons[i].Text = "↑";
                        break;
                    case ActionBlockType.Right:
                        buttons[i].Text = "→";
                        break;
                    case ActionBlockType.Left:
                        buttons[i].Text = "←";
                        break;
                    case ActionBlockType.One:
                        buttons[i].Text = "F1";
                        break;
                    case ActionBlockType.Two:
                        buttons[i].Text = "F2";
                        break;
                    case ActionBlockType.Blue:
                        buttons[i].BackColor = Color.Blue;
                        break;
                    case ActionBlockType.Red:
                        buttons[i].BackColor = Color.Red;
                        break;
                    case ActionBlockType.Yellow:
                        buttons[i].BackColor = Color.Yellow;
                        break;
                }
                buttons[i].MouseDown += new MouseEventHandler(ActionBlock_MouseDown);
                ActionBlockTypeSection.Controls.Add(buttons[i]);
            }
        }

        public void CreateReceivingActionBlockSection()
        {
            TextBox[] textBoxes = new TextBox[json.MaxActionBlock];
            mainActions = new ActionBlockType[json.MaxActionBlock];

            for (int i = 0; i < json.MaxActionBlock; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].Width = ACTION_BLOCK_TYPE_SIZE;
                textBoxes[i].Height = ACTION_BLOCK_TYPE_SIZE;
                textBoxes[i].DragOver += ActionBlock_DragOver;
                textBoxes[i].DragEnter += ActionBlock_DragEnter;
                textBoxes[i].DragDrop += ActionBlock_DragDrop;

                textBoxes[i].AllowDrop = true;
                textBoxes[i].
                MainActionSection.Controls.Add(textBoxes[i]);
            }
        }

        // Set the effect filter and allow the drop on this control
        private void ActionBlock_DragOver(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.All;

        private void ActionBlock_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.All;

        // React to the drop on this control
        private void ActionBlock_DragDrop(object sender, DragEventArgs e)
        {
            string data = (string)e.Data.GetData(typeof(string));
            ((TextBox)sender).Text = 

            switch (data)
            {
                case "↑":
                    mainActions[i] = ActionBlockType.
                    buttons[i].Text = "↑";
                    break;
                case ActionBlockType.Right:
                    buttons[i].Text = "→";
                    break;
                case ActionBlockType.Left:
                    buttons[i].Text = "←";
                    break;
                case ActionBlockType.One:
                    buttons[i].Text = "F1";
                    break;
                case ActionBlockType.Two:
                    buttons[i].Text = "F2";
                    break;
                case ActionBlockType.Blue:
                    buttons[i].BackColor = Color.Blue;
                    break;
                case ActionBlockType.Red:
                    buttons[i].BackColor = Color.Red;
                    break;
                case ActionBlockType.Yellow:
                    buttons[i].BackColor = Color.Yellow;
                    break;
            }
        }
            

        //jsonファイルの読み出し
        private StageJson ReadFieldJson(string name)
        {
            var sr = new StreamReader(@".\Fields\" + name + ".json", Encoding.GetEncoding("utf-8"));
            var input = sr.ReadToEnd();
            sr.Close();
            var deserialized = JsonConvert.DeserializeObject<StageJson>(input);
            return deserialized;
        }
    }
}
