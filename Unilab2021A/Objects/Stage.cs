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
        private FlowLayoutPanel SecondFunctionSection { get; set; }
        private Action<object, MouseEventArgs> ActionBlock_MouseDown { get; set; }
        private bool[,] isRoad = new bool[16, 12];//道か草かの判定

        public Stage(Graphics graphics, FlowLayoutPanel actionBlockTypeSection, FlowLayoutPanel firstFunctionSection,FlowLayoutPanel secondFunctionSection, Action<object, MouseEventArgs> actionBlock_MouseDown)
        {
            Graphics = graphics;
            ActionBlockTypeSection = actionBlockTypeSection;
            ActionBlock_MouseDown = actionBlock_MouseDown;
            FirstFunctionSection = firstFunctionSection;
            SecondFunctionSection = secondFunctionSection;

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
            StartPosition_Y = json.StartPosition[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
        }

        public void CreatePath()
        {
            Image roadImage = Image.FromFile(@".\Images\Road.png");
            Image noneImage = Image.FromFile(@".\Images\Background.png");
            Image enemyImage = Image.FromFile(@".\Images\Enemy.png");
            Image swordImage = Image.FromFile(@".\Images\Sword.png");
            Image blueblockImage = Image.FromFile(@".\Images\BlueBlock.png");//json.Path[i].Image = 4として設定
            Image redblockImage = Image.FromFile(@".\Images\RedBlock.png");//json.Path[i].Image = 5として設定
            Image yellowblockImage = Image.FromFile(@".\Images\YellowBlock.png");//json.Path[i].Image = 6として設定

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
                Graphics.DrawImage(roadImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
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
                else if (json.Path[i].Image == ImageType.Sword)
                {
                    Graphics.DrawImage(swordImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
                else if (json.Path[i].Image == ImageType.Blue)
                {
                    Graphics.DrawImage(blueblockImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
                else if (json.Path[i].Image == ImageType.Red)
                {
                    Graphics.DrawImage(redblockImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
                else if (json.Path[i].Image == ImageType.Yellow)
                {
                    Graphics.DrawImage(yellowblockImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
            }
        }

        private void CreateActionBlockTypeSection()
        {
            Button[] buttons = new Button[json.ActionBlocks.Count];

            for (int i = 0; i < json.ActionBlocks.Count; i++)
            {
                buttons[i] = new Button();
                buttons[i].Width = Shares.ACTION_BLOCK_CELL_SIZE;
                buttons[i].Height = Shares.ACTION_BLOCK_CELL_SIZE;
                switch (json.ActionBlocks[i])
                {
                    case ActionBlockType.GoStraight:
                        buttons[i].Text = "↑";
                        break;
                    case ActionBlockType.TurnRight:
                        buttons[i].Text = "→";
                        break;
                    case ActionBlockType.TurnLeft:
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
            TextBox[] textBoxes = new TextBox[json.MaxActionBlockCounts[0]];

            for (int i = 0; i < json.MaxActionBlockCounts[0]; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].Width = Shares.ACTION_BLOCK_CELL_SIZE;
                textBoxes[i].Height = Shares.ACTION_BLOCK_CELL_SIZE;
                textBoxes[i].DragOver += ActionBlock_DragOver;
                textBoxes[i].DragEnter += ActionBlock_DragEnter;
                textBoxes[i].DragDrop += ActionBlock_DragDrop;

                textBoxes[i].Name = i.ToString();
                textBoxes[i].AllowDrop = true;
                FirstFunctionSection.Controls.Add(textBoxes[i]);
            }

            //関数が2つある場合
            if (json.MaxActionBlockCounts.Count==2)
            {
                TextBox[] secondTextBoxes = new TextBox[json.MaxActionBlockCounts[1]];

                for (int i = 0; i < json.MaxActionBlockCounts[1]; i++)
                {
                    secondTextBoxes[i] = new TextBox();
                    secondTextBoxes[i].Width = Shares.ACTION_BLOCK_CELL_SIZE;
                    secondTextBoxes[i].Height = Shares.ACTION_BLOCK_CELL_SIZE;
                    secondTextBoxes[i].DragOver += ActionBlock_DragOver;
                    secondTextBoxes[i].DragEnter += ActionBlock_DragEnter;
                    secondTextBoxes[i].DragDrop += ActionBlock_DragDrop;

                    secondTextBoxes[i].Name = i.ToString();
                    secondTextBoxes[i].AllowDrop = true;
                    SecondFunctionSection.Controls.Add(secondTextBoxes[i]);
                }
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
                        FirstFunction[i] = ActionBlockType.GoStraight;
                        break;
                    case "→":
                        FirstFunction[i] = ActionBlockType.TurnRight;
                        break;
                    case "←":
                        FirstFunction[i] = ActionBlockType.TurnLeft;
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
                        FirstFunction.Add(ActionBlockType.GoStraight);
                        break;
                    case "→":
                        FirstFunction.Add(ActionBlockType.TurnRight);
                        break;
                    case "←":
                        FirstFunction.Add(ActionBlockType.TurnLeft);
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
