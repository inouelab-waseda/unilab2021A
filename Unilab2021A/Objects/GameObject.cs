using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using Unilab2021A.Helpers;

namespace Unilab2021A.Objects
{
    class GameObject
    {
        /* GameObjectの説明
         * 
         * GameObject全てに共通する性質を並べて親クラスとする
         * つまり各オブジェクトは各々これを継承する
         * 以下のメンバ変数を有する
         * 
         * x  :オブジェクトのx座標
         * y  :オブジェクトのy座標
         * Direction :向いている方向
         * Bitmaps[] :オブジェクトの向きごとの画像
         * IsAlive   :生きているか否か
         * CanMove   :その上を動けるかどうか
         * Color     :仮置きで色置いてるだけ(?)
        */
        private int x, y;
        //向き
        public Types.Direction Direction { get; set; } = Types.Direction.None;

        public int X
        {
            /* xのプロパティ
             * ここに代入すればxを実質publicとして扱える
             */
            get => x;
            set
            {
                /* xを更新する際、x座標が増えたら右を向く
                 */
                if (value == x + 1) Direction = Types.Direction.Right;
                else if (value == x - 1) Direction = Types.Direction.Left;
                x = value;
            }
        }
        public int Y
        {
            get => y;
            set
            {
                if (value == y + 1) Direction = Types.Direction.Down;
                else if (value == y - 1) Direction = Types.Direction.Up;
                y = value;
            }
        }

        //コンストラクタ(初期化)
        public GameObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Bitmap[] Bitmaps { get; private set; } = new Bitmap[Enum.GetNames(typeof(Types.Direction)).Length];
        /*Enum.GetNames(typeof(hogehoge))  ->  Enum型のhogehogeを列挙した配列
         *それぞれの向きに対応した画像を格納している
         *Bitmap[0]:向きがないときの画像
         *Bitmap[1]:下を向いている時の画像
         *...
         */

        
        public bool IsAlive { get; set; } = true;
        public void Die() => IsAlive = false;

       
        public virtual bool CanMove { get; } = true;
        //初期値はtrue。木とゴールはfalseにそれぞれでoverride

        public Brush Color { get; set; } = Brushes.Red;

        public virtual void Draw(Graphics graphics, float width, float height)
        {
            if (!IsAlive) return; // 生きてないなら表示しない
            graphics.FillRectangle(Color, X * width, Y * height, width, height);
            switch (Direction)
            {
                case Types.Direction.Right:
                    graphics.FillRectangle(Brushes.Black, (4 * X + 3) * width / 4, Y * height, width / 4, height);
                    break;
                case Types.Direction.Left:
                    graphics.FillRectangle(Brushes.Black, X * width, Y * height, width / 4, height);
                    break;
                case Types.Direction.Up:
                    graphics.FillRectangle(Brushes.Black, X * width, Y * height, width, height / 4);
                    break;
                case Types.Direction.Down:
                    graphics.FillRectangle(Brushes.Black, X * width, (4 * Y + 3) * height / 4, width, height / 4);
                    break;
                default:
                    break;
            }
        }
        public Bitmap GetBitmap(string name)
        {
            /*
            入力:画像ファイル名
            対象画像を読み込む
            */
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("unilab2019.Images." + name);
            Bitmap bmp = new Bitmap(stream);
            return bmp;
        }

        public void Move()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    break;

                case Types.Direction.Up:
                    Y--;
                    break;

                case Types.Direction.Down:
                    Y++;
                    break;

                case Types.Direction.Right:
                    X++;
                    break;

                case Types.Direction.Left:
                    X--;
                    break;
            }
        }
        public void TurnRight()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    break;

                case Types.Direction.Up:
                    Direction = Types.Direction.Right;
                    break;

                case Types.Direction.Down:
                    Direction = Types.Direction.Left;
                    break;

                case Types.Direction.Right:
                    Direction = Types.Direction.Down;
                    break;

                case Types.Direction.Left:
                    Direction = Types.Direction.Up;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    break;

                case Types.Direction.Up:
                    Direction = Types.Direction.Left;
                    break;

                case Types.Direction.Down:
                    Direction = Types.Direction.Right;
                    break;

                case Types.Direction.Right:
                    Direction = Types.Direction.Up;
                    break;

                case Types.Direction.Left:
                    Direction = Types.Direction.Down;
                    break;
            }
        }

        #region 一人称視点で見た時の前後左右の座標
        public int ForwardX()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    return X;
                case Types.Direction.Up:
                    return X;
                case Types.Direction.Down:
                    return X;
                case Types.Direction.Right:
                    return X + 1;
                case Types.Direction.Left:
                    return X - 1;
            }
        }

        public int ForwardY()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    return Y;
                case Types.Direction.Up:
                    return Y - 1;
                case Types.Direction.Down:
                    return Y + 1;
                case Types.Direction.Right:
                    return Y;
                case Types.Direction.Left:
                    return Y;
            }
        }

        public int BackX()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    return X;
                case Types.Direction.Up:
                    return X;
                case Types.Direction.Down:
                    return X;
                case Types.Direction.Right:
                    return X - 1;
                case Types.Direction.Left:
                    return X + 1;
            }
        }

        public int BackY()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    return Y;
                case Types.Direction.Up:
                    return Y + 1;
                case Types.Direction.Down:
                    return Y - 1;
                case Types.Direction.Right:
                    return Y;
                case Types.Direction.Left:
                    return Y;
            }
        }

        public int RightX()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    return X;
                case Types.Direction.Up:
                    return X + 1;
                case Types.Direction.Down:
                    return X - 1;
                case Types.Direction.Right:
                    return X;
                case Types.Direction.Left:
                    return X;
            }
        }

        public int RightY()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    return Y;
                case Types.Direction.Up:
                    return Y;
                case Types.Direction.Down:
                    return Y;
                case Types.Direction.Right:
                    return Y + 1;
                case Types.Direction.Left:
                    return Y - 1;
            }
        }

        public int LeftX()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    return X;
                case Types.Direction.Up:
                    return X - 1;
                case Types.Direction.Down:
                    return X + 1;
                case Types.Direction.Right:
                    return X;
                case Types.Direction.Left:
                    return X;
            }
        }

        public int LeftY()
        {
            switch (Direction)
            {
                default:
                case Types.Direction.None:
                    return Y;
                case Types.Direction.Up:
                    return Y;
                case Types.Direction.Down:
                    return Y;
                case Types.Direction.Right:
                    return Y - 1;
                case Types.Direction.Left:
                    return Y + 1;
            }
        }
        #endregion
    }
}
