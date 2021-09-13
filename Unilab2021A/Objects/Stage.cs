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
using Unilab2021A.Helpers;
using static Unilab2021A.Helpers.Types;

namespace Unilab2021A.Objects
{
    class Stage
    {
        public int StartPosition_X { get; private set; }
        public int StartPosition_Y { get; private set; }
        public List<ActionBlockType> FirstFunction { get; private set; }

        private StageJson json;
        private Graphics Graphics { get; set; }
        private FlowLayoutPanel ActionBlockTypeSection { get; set; }
        private FlowLayoutPanel FirstFunctionSection { get; set; }
        private Action<object, MouseEventArgs> ActionBlock_MouseDown { get; set; }
        private bool[,] isRoad = new bool[16, 12];//道か草かの判定

        public Stage(Graphics graphics, FlowLayoutPanel actionBlockTypeSection, FlowLayoutPanel firstFunctionSection, Action<object, MouseEventArgs> actionBlock_MouseDown)
        {
            Graphics = graphics;
            ActionBlockTypeSection = actionBlockTypeSection;
            ActionBlock_MouseDown = actionBlock_MouseDown;
            FirstFunctionSection = firstFunctionSection;

            // jsonファイルの読み込みなど(StageName)
            // --------
            json = ReadFieldJson("1_1");

            //道の作成
            CreatePath();

            //アクションブロックの作成
            CreateActionBlockTypeSection();

            //関数セクションの作成
            CreateFunctionSection();

            //First関数
            FirstFunction = new List<ActionBlockType>();

            //初期位置の座標
            StartPosition_X = json.StartPosition[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM;
            StartPosition_Y = (json.StartPosition[1] - 1) * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
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
                    isRoad[i, j] = true;
                }
            }

            //道の作成
            for (int i = 0; i < json.Path.Count; i++)
            {
                if (json.Path[i].Image == ImageType.Others)
                {
                    //中島4/16 GraphicsがWIDTH×HEIGHTで表現されているため、WIDTH_CELL_NUM×HEIGHT_CELL_NUMに無理やり変えた,画像サイズでそれぞれ+1しているのは+1しないとintに変化しているため、微妙にサイズが小さくなりつなぎ目が出るから
                    //中島4/16 具体的な数字を使ったためうまく表現する方法があるかも
                    Graphics.DrawImage(noneImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                    isRoad[json.Path[i].Position[0], json.Path[i].Position[1]] = false;//草はfalseに
                }
                else if (json.Path[i].Image == ImageType.Enemy)
                {
                    Graphics.DrawImage(enemyImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
            }
        }

        private void CreateActionBlockTypeSection()
        {
            Button[] buttons = new Button[json.ActionBlockTypes.Count];

            for (int i = 0; i < json.ActionBlockTypes.Count; i++)
            {
                buttons[i] = new Button();
                buttons[i].Width = Shares.ACTION_BLOCK_TYPE_SIZE;
                buttons[i].Height = Shares.ACTION_BLOCK_TYPE_SIZE;
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
                    case ActionBlockType.First:
                        buttons[i].Text = "F1";
                        break;
                    case ActionBlockType.Second:
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

        private void CreateFunctionSection()
        {
            TextBox[] textBoxes = new TextBox[json.MaxActionBlock];

            for (int i = 0; i < json.MaxActionBlock; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].Width = Shares.ACTION_BLOCK_TYPE_SIZE;
                textBoxes[i].Height = Shares.ACTION_BLOCK_TYPE_SIZE;
                textBoxes[i].DragOver += ActionBlock_DragOver;
                textBoxes[i].DragEnter += ActionBlock_DragEnter;
                textBoxes[i].DragDrop += ActionBlock_DragDrop;

                textBoxes[i].Name = i.ToString();
                textBoxes[i].AllowDrop = true;
                FirstFunctionSection.Controls.Add(textBoxes[i]);
            }
        }

        public void Reset()
        {
            CreatePath();
            FirstFunction = new List<ActionBlockType>();
            FirstFunctionSection.Controls.Clear();
            CreateFunctionSection();

        }

        // Set the effect filter and allow the drop on this control
        private void ActionBlock_DragOver(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.All;

        private void ActionBlock_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.All;

    
        private void ActionBlock_DragDrop(object sender, DragEventArgs e)
        {
            string data = (string)e.Data.GetData(typeof(string));
            TextBox textBox = (TextBox)sender;
            int i = int.Parse(textBox.Name);

            //すでにブロックがあった場合
            if (textBox.Text != "")
            {
                switch (data)
                {
                    case "↑":
                        FirstFunction[i] = ActionBlockType.Up;
                        break;
                    case "→":
                        FirstFunction[i] = ActionBlockType.Right;
                        break;
                    case "←":
                        FirstFunction[i] = ActionBlockType.Left;
                        break;
                    case "F1":
                        FirstFunction[i] = ActionBlockType.First;
                        break;
                    case "F2":
                        FirstFunction[i] = ActionBlockType.Second;
                        break;
                }
            }
            else
            {
                switch (data)
                {
                    case "↑":
                        FirstFunction.Add(ActionBlockType.Up);
                        break;
                    case "→":
                        FirstFunction.Add(ActionBlockType.Right);
                        break;
                    case "←":
                        FirstFunction.Add(ActionBlockType.Left);
                        break;
                    case "F1":
                        FirstFunction.Add(ActionBlockType.First);
                        break;
                    case "F2":
                        FirstFunction.Add(ActionBlockType.Second);
                        break;
                }
            }



            textBox.Text = data;
        }

        //道かどうか判定
        public bool IsRoad(DirectionType directionType, int x, int y)
        {

            bool result = false;
            switch (directionType)
            {
                case DirectionType.Up:
                    result = isRoad[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM), y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM) - 1];
                    break;
                case DirectionType.Down:
                    result = isRoad[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM), y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM) + 1];
                    break;
                case DirectionType.Left:
                    result = isRoad[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM) - 1, y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM)];
                    break;
                case DirectionType.Right:
                    result = isRoad[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM) + 1, y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM)];
                    break;
            }

            return result;

        }

        public DirectionType getDirection(ActionBlockType type)
        {
            DirectionType result = DirectionType.Up;
            switch (type)
            {
                case ActionBlockType.Up:
                    result = DirectionType.Up;
                    break;
                //case ActionBlockType.Down:
                //    result = DirectionType.Down;
                //    break;
                case ActionBlockType.Right:
                    result = DirectionType.Right;
                    break;
                case ActionBlockType.Left:
                    result = DirectionType.Left;
                    break;
            }

            return result;
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
