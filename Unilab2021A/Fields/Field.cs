using System;
using System.Collections.Generic;
using static Unilab2021A.Helpers.Types;

namespace Unilab2021A.Fields
{
    class StageJson
    {
        public string StageName { get; set; }
        public List<int> StartPosition { get; set; }
        public DirectionType StartDirection { get; set; }
        public List<Cell> Path { get; set; } = new List<Cell>();
        public List<BlockType> Blocks { get; set; }
        public int FunctionCount { get; set; } //1か2のみ受け付ける
        public List<int> MaxBlockCounts { get; set; } //FunctionCountの数に合わせる
    }

    class Cell
    {
        public ImageType Image { get; set; }
        public List<int> Position { get; set; }
    }
}
