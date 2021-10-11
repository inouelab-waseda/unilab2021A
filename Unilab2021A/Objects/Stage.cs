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
        public List<ActionBlockType> SecondActions { get; private set; }
        public ConditionBlockType[] SecondConditions { get; private set; }

        private StageJson Json { get; }
        private Graphics Graphics { get; }

        private FlowLayoutPanel BlockTypeSection { get; }
        private FlowLayoutPanel FirstFunctionSection { get; }
        private FlowLayoutPanel SecondFunctionSection { get; }
        private Action<object, MouseEventArgs> Block_MouseDown { get; }

        private bool[,] isRoad = new bool[16, 12];//道か草かの判定
        private ConditionBlockType[,] cellConditions = new ConditionBlockType[16, 12];//セルの状態 (色)
        private bool[,] isSword = new bool[16, 12];//剣があるかないか
        private bool[,] isEnemy = new bool[16, 12];//敵がいるかないか

        private Image roadImage { get; }
        private Image noneImage { get; }
        private Image enemyImage { get; }
        private Image swordImage { get; }
        private Image blueblockImage { get; }//Json.Path[i].Image = 4として設定
        private Image redblockImage { get; }//Json.Path[i].Image = 5として設定
        private Image yellowblockImage { get; }//Json.Path[i].Image = 6として設定

        public Stage(Graphics graphics, FlowLayoutPanel actionBlockTypeSection, FlowLayoutPanel firstFunctionSection, FlowLayoutPanel secondFunctionSection, Action<object, MouseEventArgs> block_MouseDown)
        {
            Graphics = graphics;
            BlockTypeSection = actionBlockTypeSection;
            Block_MouseDown = block_MouseDown;
            FirstFunctionSection = firstFunctionSection;
            SecondFunctionSection = secondFunctionSection;

            //画像の設定
            roadImage = Shares.GetBitmap(@"Background\Road.png");
            noneImage = Shares.GetBitmap(@"Background\No_Road.png");
            enemyImage = Shares.GetBitmap(@"Objects\Enemy.png");
            swordImage = Shares.GetBitmap(@"Objects\Sword.png");
            blueblockImage = Shares.GetBitmap(@"Blocks\BlueBlock.png");//Json.Path[i].Image = 4として設定
            redblockImage = Shares.GetBitmap(@"Blocks\RedBlock.png");//Json.Path[i].Image = 5として設定
            yellowblockImage = Shares.GetBitmap(@"Blocks\YellowBlock.png");//Json.Path[i].Image = 6として設定

            // Jsonファイルの読み込みなど(StageName)
            // --------
            Json = ReadFieldJson("1_1");

            //道の作成
            initPath();

            //ブロックの作成
            CreateBlockTypeSection();

            //関数セクションの作成
            CreateFunctionSection();

            //First関数
            FirstActions = new List<ActionBlockType>();
            FirstConditions = new ConditionBlockType[Json.MaxBlockCounts[0]];

            //Second関数
            SecondActions = new List<ActionBlockType>();
            if (Json.FunctionCount == 2) SecondConditions = new ConditionBlockType[Json.MaxBlockCounts[1]];

            //初期位置の座標
            StartPosition_X = Json.StartPosition[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM;
            StartPosition_Y = Json.StartPosition[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
        }

        private void initPath()
        {
            //flagの初期化
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    isRoad[i, j] = true;
                    cellConditions[i, j] = ConditionBlockType.None;
                    isSword[i, j] = false;
                    isEnemy[i, j] = false;
                }
            }

            //道の作成
            for (int i = 0; i < Json.Path.Count; i++)
            {
                int x = Json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                int y = Json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                int width = Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1;
                int height = Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1;

                Graphics.DrawImage(roadImage, x, y, width, height);
                if (Json.Path[i].Image == ImageType.Others)
                {
                    //中島4/16 GraphicsがWIDTH×HEIGHTで表現されているため、WIDTH_CELL_NUM×HEIGHT_CELL_NUMに無理やり変えた,画像サイズでそれぞれ+1しているのは+1しないとintに変化しているため、微妙にサイズが小さくなりつなぎ目が出るから
                    //中島4/16 具体的な数字を使ったためうまく表現する方法があるかも
                    Graphics.DrawImage(noneImage, x, y, width, height);
                    isRoad[Json.Path[i].Position[0], Json.Path[i].Position[1]] = false;//草はfalseに
                }
                else if (Json.Path[i].Image == ImageType.Enemy)
                {
                    isEnemy[Json.Path[i].Position[0], Json.Path[i].Position[1]] = true;//敵がいる場所はtrue
                    Graphics.DrawImage(enemyImage, x, y, width, height);
                }
                else if (Json.Path[i].Image == ImageType.Sword)
                {
                    isSword[Json.Path[i].Position[0], Json.Path[i].Position[1]] = true;//剣がある場所はtrue
                    Graphics.DrawImage(swordImage, x, y, width, height);
                }
                else if (Json.Path[i].Image == ImageType.Blue)
                {
                    cellConditions[Json.Path[i].Position[0], Json.Path[i].Position[1]] = ConditionBlockType.Blue;
                    Graphics.DrawImage(blueblockImage, x, y, width, height);
                }
                else if (Json.Path[i].Image == ImageType.Red)
                {
                    cellConditions[Json.Path[i].Position[0], Json.Path[i].Position[1]] = ConditionBlockType.Red;
                    Graphics.DrawImage(redblockImage, x, y, width, height);
                }
                else if (Json.Path[i].Image == ImageType.Yellow)
                {
                    cellConditions[Json.Path[i].Position[0], Json.Path[i].Position[1]] = ConditionBlockType.Yellow;
                    Graphics.DrawImage(yellowblockImage, x, y, width, height);
                }
            }
        }

        public void DrawPath()
        {

            //道の作成
            for (int i = 0; i < Json.Path.Count; i++)
            {
                int x = Json.Path[i].Position[0] * Shares.WIDTH / Shares.WIDTH_CELL_NUM;
                int y = Json.Path[i].Position[1] * Shares.HEIGHT / Shares.HEIGHT_CELL_NUM;
                int width = Shares.WIDTH / Shares.WIDTH_CELL_NUM + 1;
                int height = Shares.HEIGHT / Shares.HEIGHT_CELL_NUM + 1;

                Graphics.DrawImage(roadImage, x, y, width, height);
                if (Json.Path[i].Image == ImageType.Others)
                {
                    //中島4/16 GraphicsがWIDTH×HEIGHTで表現されているため、WIDTH_CELL_NUM×HEIGHT_CELL_NUMに無理やり変えた,画像サイズでそれぞれ+1しているのは+1しないとintに変化しているため、微妙にサイズが小さくなりつなぎ目が出るから
                    //中島4/16 具体的な数字を使ったためうまく表現する方法があるかも
                    Graphics.DrawImage(noneImage, x, y, width, height);
                    isRoad[Json.Path[i].Position[0], Json.Path[i].Position[1]] = false;//草はfalseに
                }
                else if (Json.Path[i].Image == ImageType.Blue)
                {
                    cellConditions[Json.Path[i].Position[0], Json.Path[i].Position[1]] = ConditionBlockType.Blue;
                    Graphics.DrawImage(blueblockImage, x, y, width, height);
                }
                else if (Json.Path[i].Image == ImageType.Red)
                {
                    cellConditions[Json.Path[i].Position[0], Json.Path[i].Position[1]] = ConditionBlockType.Red;
                    Graphics.DrawImage(redblockImage, x, y, width, height);
                }
                else if (Json.Path[i].Image == ImageType.Yellow)
                {
                    cellConditions[Json.Path[i].Position[0], Json.Path[i].Position[1]] = ConditionBlockType.Yellow;
                    Graphics.DrawImage(yellowblockImage, x, y, width, height);
                }

                //可変なもの
                if (isEnemy[Json.Path[i].Position[0], Json.Path[i].Position[1]])
                {
                    Graphics.DrawImage(enemyImage, x, y, width, height);
                }
                if (isSword[Json.Path[i].Position[0], Json.Path[i].Position[1]])
                {
                    Graphics.DrawImage(swordImage, x, y, width, height);
                }
            }
        }


        private void CreateBlockTypeSection()
        {
            PictureBox[] pictureBoxes = new PictureBox[Json.Blocks.Count];

            for (int i = 0; i < Json.Blocks.Count; i++)
            {
                pictureBoxes[i] = new PictureBox();
                pictureBoxes[i].Width = Shares.BLOCK_CELL_SIZE;
                pictureBoxes[i].Height = Shares.BLOCK_CELL_SIZE;
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxes[i].Name = i.ToString();
                pictureBoxes[i].Image = TransformBlockTypeIntoImage(Json.Blocks[i]);
                pictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxes[i].MouseDown += new MouseEventHandler(Block_MouseDown);
                BlockTypeSection.Controls.Add(pictureBoxes[i]);
            }
        }

        //pictureboxからtypeに変換する
        public BlockType TransformNameIntoBlockType(string name)
        {
            return Json.Blocks[int.Parse(name)];
        }

        //blocktypeからimageに変換する
        private Image TransformBlockTypeIntoImage(BlockType type)
        {
            switch (type)
            {
                case BlockType.GoStraight:
                    return Shares.GetBitmap(@"Blocks\Go_Straight_Black.PNG");
                case BlockType.TurnRight:
                    return Shares.GetBitmap(@"Blocks\Turn_Right_Black.PNG");
                case BlockType.TurnLeft:
                    return Shares.GetBitmap(@"Blocks\Turn_Left_Black.PNG");
                case BlockType.First:
                    return Shares.GetBitmap(@"Blocks\F1_Black.PNG");
                case BlockType.Second:
                    return Shares.GetBitmap(@"Blocks\F2_Black.PNG");
                case BlockType.Blue:
                    return Shares.GetBitmap(@"Blocks\Blue.PNG");
                case BlockType.Red:
                    return Shares.GetBitmap(@"Blocks\Red.PNG");
                case BlockType.Yellow:
                    return Shares.GetBitmap(@"Blocks\Yellow.PNG");
                default:
                    return Shares.GetBitmap(@"Blocks\Go_Straight_Black.PNG");
            }
        }

        private void CreateFunctionSection()
        {
            PictureBox[] firstPictureBoxes = new PictureBox[Json.MaxBlockCounts[0]];

            for (int i = 0; i < Json.MaxBlockCounts[0]; i++)
            {
                firstPictureBoxes[i] = new PictureBox();
                firstPictureBoxes[i].Width = Shares.BLOCK_CELL_SIZE;
                firstPictureBoxes[i].Height = Shares.BLOCK_CELL_SIZE;
                firstPictureBoxes[i].DragOver += Block_DragOver;
                firstPictureBoxes[i].DragEnter += Block_DragEnter;
                firstPictureBoxes[i].DragDrop += Block_DragDrop;
                firstPictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                firstPictureBoxes[i].BackgroundImageLayout = ImageLayout.Stretch;
                firstPictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                firstPictureBoxes[i].Name = i.ToString();
                firstPictureBoxes[i].AllowDrop = true;
                FirstFunctionSection.Controls.Add(firstPictureBoxes[i]);
            }

            //関数が2つある場合
            if (Json.FunctionCount == 2)
            {
                PictureBox[] secondPictureBoxes = new PictureBox[Json.MaxBlockCounts[1]];

                for (int i = 0; i < Json.MaxBlockCounts[1]; i++)
                {
                    secondPictureBoxes[i] = new PictureBox();
                    secondPictureBoxes[i].Width = Shares.BLOCK_CELL_SIZE;
                    secondPictureBoxes[i].Height = Shares.BLOCK_CELL_SIZE;
                    secondPictureBoxes[i].DragOver += Block_DragOver;
                    secondPictureBoxes[i].DragEnter += Block_DragEnter;
                    secondPictureBoxes[i].DragDrop += Block_DragDrop;
                    secondPictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    secondPictureBoxes[i].BackgroundImageLayout = ImageLayout.Stretch;
                    secondPictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                    secondPictureBoxes[i].Name = i.ToString();
                    secondPictureBoxes[i].AllowDrop = true;
                    SecondFunctionSection.Controls.Add(secondPictureBoxes[i]);
                }
            }
        }

        public void Reset()
        {
            initPath();
            FirstActions = new List<ActionBlockType>();
            FirstConditions = new ConditionBlockType[FirstConditions.Length];
            FirstFunctionSection.Controls.Clear();
            
            SecondActions = new List<ActionBlockType>();
            if (Json.FunctionCount == 2) SecondConditions = new ConditionBlockType[SecondConditions.Length];
            SecondFunctionSection.Controls.Clear();
            CreateFunctionSection();
        }

        // Set the effect filter and allow the drop on this control
        private void Block_DragOver(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.All;

        private void Block_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.All;


        private void Block_DragDrop(object receiver, DragEventArgs e)
        {
            BlockType data = (BlockType)e.Data.GetData(typeof(BlockType));

            if(data==BlockType.Blue|| data == BlockType.Red || data == BlockType.Yellow)
            {
                ConditionBlock_DragDrop((PictureBox)receiver, data);
            }
            else
            {
                ActionBlock_DragDrop((PictureBox)receiver, data);
            }

        }

        private void ActionBlock_DragDrop(PictureBox pictureBox,BlockType data)
        {
            int i = int.Parse(pictureBox.Name);

            //すでにブロックがあった場合
            if (pictureBox.Image != null)
            {
                switch (data)
                {
                    case BlockType.GoStraight:
                        FirstActions[i] = ActionBlockType.GoStraight;
                        break;
                    case BlockType.TurnRight:
                        FirstActions[i] = ActionBlockType.TurnRight;
                        break;
                    case BlockType.TurnLeft:
                        FirstActions[i] = ActionBlockType.TurnLeft;
                        break;
                    case BlockType.First:
                        FirstActions[i] = ActionBlockType.First;
                        break;
                    case BlockType.Second:
                        FirstActions[i] = ActionBlockType.Second;
                        break;
                }
            }
            else
            {
                switch (data)
                {
                    case BlockType.GoStraight:
                        FirstActions.Add(ActionBlockType.GoStraight);
                        break;
                    case BlockType.TurnRight:
                        FirstActions.Add(ActionBlockType.TurnRight);
                        break;
                    case BlockType.TurnLeft:
                        FirstActions.Add(ActionBlockType.TurnLeft);
                        break;
                    case BlockType.First:
                        FirstActions.Add(ActionBlockType.First);
                        break;
                    case BlockType.Second:
                        FirstActions.Add(ActionBlockType.Second);
                        break;
                }
            }
            pictureBox.Image = TransformBlockTypeIntoImage(data);
        }

        private void ConditionBlock_DragDrop(PictureBox pictureBox, BlockType data)
        {

                int i = int.Parse(pictureBox.Name);



                if (data == BlockType.Blue)
                {
                    FirstConditions[i] = ConditionBlockType.Blue;
                }
                else if (data == BlockType.Red)
                {
                    FirstConditions[i] = ConditionBlockType.Red;
                }
                else if (data == BlockType.Yellow)
                {
                    FirstConditions[i] = ConditionBlockType.Yellow;
                }


            pictureBox.BackgroundImage = TransformBlockTypeIntoImage(data);

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
        public bool CanAct(ConditionBlockType personCondition, int x, int y)
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

        //剣があるかどうか判定
        public bool IsSword(int x, int y)
        {

            bool result = isSword[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM), y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM)];

            //もし剣があれば、取得するので剣は消える
            if (result)
            {
                isSword[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM), y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM)] = false;

                return true;
            }

            return false;
        }

        //敵がいるかどうか判定
        public bool IsEnemy(int swordCount, int x, int y)
        {

            bool result = isEnemy[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM), y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM)];

            //もし剣があれば、倒すので敵は消える
            if (result && swordCount > 0)
            {
                isEnemy[x / (Shares.WIDTH / Shares.WIDTH_CELL_NUM), y / (Shares.HEIGHT / Shares.HEIGHT_CELL_NUM)] = false;

                return true;
            }

            return false;
        }

        //敵が全滅したかどうか判定
        public bool IsEnemyRemained()
        {
            bool result = false;
            foreach (bool enemy in isEnemy)
            {
                if (enemy)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        //Jsonファイルの読み出し
        private StageJson ReadFieldJson(string name)
        {
            var sr = new StreamReader(@".\Fields\" + name + ".Json", Encoding.GetEncoding("utf-8"));
            var input = sr.ReadToEnd();
            sr.Close();
            var deserialized = JsonConvert.DeserializeObject<StageJson>(input);
            return deserialized;
        }
    }
}
