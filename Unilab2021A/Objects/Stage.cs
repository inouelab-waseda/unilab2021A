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
        public List<ActionBlockType> FirstActions { get; private set; }
        public ConditionBlockType[] FirstConditions { get; private set; }

        private StageJson json;
        private Graphics Graphics { get; }
        private FlowLayoutPanel BlockTypeSection { get; }
        private FlowLayoutPanel FirstFunctionSection { get; }
        private FlowLayoutPanel SecondFunctionSection { get; }
        private Action<object, MouseEventArgs> ActionBlock_MouseDown { get; }
        private Action<object, MouseEventArgs> ConditionBlock_MouseDown { get; }
        private bool[,] isRoad = new bool[16, 12];//道か草かの判定
        private ConditionBlockType[,] cellConditions = new ConditionBlockType[16, 12];//セルの状態 (色)

        public Stage(Graphics graphics, FlowLayoutPanel actionBlockTypeSection, FlowLayoutPanel firstFunctionSection,FlowLayoutPanel secondFunctionSection, Action<object, MouseEventArgs> actionBlock_MouseDown, Action<object, MouseEventArgs> conditionBlock_MouseDown)
        {
            Graphics = graphics;
            BlockTypeSection = actionBlockTypeSection;
            ActionBlock_MouseDown = actionBlock_MouseDown;
            ConditionBlock_MouseDown = conditionBlock_MouseDown;
            FirstFunctionSection = firstFunctionSection;
            SecondFunctionSection = secondFunctionSection;

            // jsonファイルの読み込みなど(StageName)
            // --------
            json = ReadFieldJson("1_1");

            //道の作成
            CreatePath();

            //ブロックの作成
            CreateBlockTypeSection();

            //関数セクションの作成
            CreateFunctionSection();

            //First関数
            FirstActions = new List<ActionBlockType>();
            FirstConditions = new ConditionBlockType[json.MaxBlockCounts[0]];

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
                    cellConditions[json.Path[i].Position[0], json.Path[i].Position[1]] = ConditionBlockType.None;
                }
                else if (json.Path[i].Image == ImageType.Enemy)
                {
                    cellConditions[json.Path[i].Position[0], json.Path[i].Position[1]] = ConditionBlockType.None;
                    Graphics.DrawImage(enemyImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
                else if (json.Path[i].Image == ImageType.Sword)
                {
                    cellConditions[json.Path[i].Position[0], json.Path[i].Position[1]] = ConditionBlockType.None;
                    Graphics.DrawImage(swordImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
                else if (json.Path[i].Image == ImageType.Blue)
                {
                    cellConditions[json.Path[i].Position[0], json.Path[i].Position[1]] = ConditionBlockType.Blue;
                    Graphics.DrawImage(blueblockImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
                else if (json.Path[i].Image == ImageType.Red)
                {
                    cellConditions[json.Path[i].Position[0], json.Path[i].Position[1]] = ConditionBlockType.Red;
                    Graphics.DrawImage(redblockImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
                else if (json.Path[i].Image == ImageType.Yellow)
                {
                    cellConditions[json.Path[i].Position[0], json.Path[i].Position[1]] = ConditionBlockType.Yellow;
                    Graphics.DrawImage(yellowblockImage, json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM, json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM, Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1, Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1);
                }
            }
        }

        private void CreateBlockTypeSection()
        {
            Button[] buttons = new Button[json.Blocks.Count];

            for (int i = 0; i < json.Blocks.Count; i++)
            {
                buttons[i] = new Button();
                buttons[i].Width = Shares.ACTION_BLOCK_CELL_SIZE;
                buttons[i].Height = Shares.ACTION_BLOCK_CELL_SIZE;
                switch (json.Blocks[i])
                {
                    case BlockType.GoStraight:
                        buttons[i].Text = "↑";
                        break;
                    case BlockType.TurnRight:
                        buttons[i].Text = "→";
                        break;
                    case BlockType.TurnLeft:
                        buttons[i].Text = "←";
                        break;
                    case BlockType.First:
                        buttons[i].Text = "F1";
                        break;
                    case BlockType.Second:
                        buttons[i].Text = "F2";
                        break;
                    case BlockType.Blue:
                        buttons[i].BackColor = Color.Blue;
                        break;
                    case BlockType.Red:
                        buttons[i].BackColor = Color.Red;
                        break;
                    case BlockType.Yellow:
                        buttons[i].BackColor = Color.Yellow;
                        break;
                }
                if (json.Blocks[i] == BlockType.Blue || json.Blocks[i] == BlockType.Red || json.Blocks[i] == BlockType.Yellow)
                {
                    buttons[i].MouseDown += new MouseEventHandler(ConditionBlock_MouseDown);
                }
                else
                {
                    buttons[i].MouseDown += new MouseEventHandler(ActionBlock_MouseDown);
                }
               
                BlockTypeSection.Controls.Add(buttons[i]);
            }
        }

        private void CreateFunctionSection()
        {
            TextBox[] firstTextBoxes = new TextBox[json.MaxBlockCounts[0]];

            for (int i = 0; i < json.MaxBlockCounts[0]; i++)
            {
                firstTextBoxes[i] = new TextBox();
                firstTextBoxes[i].Width = Shares.ACTION_BLOCK_CELL_SIZE;
                firstTextBoxes[i].Height = Shares.ACTION_BLOCK_CELL_SIZE;
                firstTextBoxes[i].DragOver += Block_DragOver;
                firstTextBoxes[i].DragEnter += Block_DragEnter;

                firstTextBoxes[i].DragDrop += ConditionBlock_DragDrop;
                firstTextBoxes[i].DragDrop += ActionBlock_DragDrop;

                firstTextBoxes[i].Name = i.ToString();
                firstTextBoxes[i].AllowDrop = true;
                FirstFunctionSection.Controls.Add(firstTextBoxes[i]);
            }

            //関数が2つある場合
            if (json.MaxBlockCounts.Count==2)
            {
                TextBox[] secondTextBoxes = new TextBox[json.MaxBlockCounts[1]];

                for (int i = 0; i < json.MaxBlockCounts[1]; i++)
                {
                    secondTextBoxes[i] = new TextBox();
                    secondTextBoxes[i].Width = Shares.ACTION_BLOCK_CELL_SIZE;
                    secondTextBoxes[i].Height = Shares.ACTION_BLOCK_CELL_SIZE;
                    secondTextBoxes[i].DragOver += Block_DragOver;
                    secondTextBoxes[i].DragEnter += Block_DragEnter;

                    secondTextBoxes[i].DragDrop += ConditionBlock_DragDrop;
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
            FirstActions = new List<ActionBlockType>();
            FirstConditions = new ConditionBlockType[FirstConditions.Length];
            FirstFunctionSection.Controls.Clear();
            CreateFunctionSection();

        }

        // Set the effect filter and allow the drop on this control
        private void Block_DragOver(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.All;

        private void Block_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.All;

    
        //ドロップされたものをアクションブロックとしたとき
        private void ActionBlock_DragDrop(object sender, DragEventArgs e)
        {
            string data = (string)e.Data.GetData(typeof(string));
            if (data == null) //状態ブロックの場合は処理しない
            {
                return;
            }
            TextBox textBox = (TextBox)sender;
            int i = int.Parse(textBox.Name);

            //すでにブロックがあった場合
            if (textBox.Text != "")
            {
                switch (data)
                {
                    case "↑":
                        FirstActions[i] = ActionBlockType.GoStraight;
                        break;
                    case "→":
                        FirstActions[i] = ActionBlockType.TurnRight;
                        break;
                    case "←":
                        FirstActions[i] = ActionBlockType.TurnLeft;
                        break;
                    case "F1":
                        FirstActions[i] = ActionBlockType.First;
                        break;
                    case "F2":
                        FirstActions[i] = ActionBlockType.Second;
                        break;
                }
            }
            else
            {
                switch (data)
                {
                    case "↑":
                        FirstActions.Add(ActionBlockType.GoStraight);
                        break;
                    case "→":
                        FirstActions.Add(ActionBlockType.TurnRight);
                        break;
                    case "←":
                        FirstActions.Add(ActionBlockType.TurnLeft);
                        break;
                    case "F1":
                        FirstActions.Add(ActionBlockType.First);
                        break;
                    case "F2":
                        FirstActions.Add(ActionBlockType.Second);
                        break;
                }
            }



            textBox.Text = data;
        }

        //ドロップされたものを状態ブロックとしたとき
        private void ConditionBlock_DragDrop(object sender, DragEventArgs e)
        {

            try
            {
                Color data = (Color)e.Data.GetData(typeof(Color));
                TextBox textBox = (TextBox)sender;
                int i = int.Parse(textBox.Name);



                if (data.Name == Color.Blue.Name)
                {
                    FirstConditions[i] = ConditionBlockType.Blue;
                }
                else if (data.Name == Color.Red.Name)
                {
                    FirstConditions[i] = ConditionBlockType.Red;
                }
                else if (data.Name == Color.Yellow.Name)
                {
                    FirstConditions[i] = ConditionBlockType.Yellow;
                }
                else if (data.Name == "Window")
                {
                    FirstConditions[i] = ConditionBlockType.None;
                }


                    textBox.BackColor = data;
            }
            catch (NullReferenceException exception)//アクションブロックの場合は処理しない
            {
                Console.WriteLine(exception.ToString());
                return;
            }

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

        //行動できるかどうか判定
        public bool CanAct(ConditionBlockType personCondition,int x, int y)
        {
            ConditionBlockType cellCondition = cellConditions[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM), y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM)];
            if (personCondition == ConditionBlockType.None)
            {
                return true;
            }
            else
            {
                return personCondition == cellCondition;
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
