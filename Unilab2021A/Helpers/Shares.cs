using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unilab2021A.Helpers
{
    static class Shares
    {
        // 定数
        public const int WIDTH = 2904;
        public const int HEIGHT = 2130;
        public const int WIDTH_CELL_NUM = 16;
        public const int HEIGHT_CELL_NUM = 12;
        public const int BLOCK_CELL_SIZE = 30;

        static public Bitmap GetBitmap(string name)
        {
            /*
            入力:画像ファイル名
            対象画像を読み込む
            */
            Bitmap bmp = new Bitmap(@".\Images\" + name);
            return bmp;
        }
    }
}
