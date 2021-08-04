using System;
using System.Collections.Generic;
using static Unilab2021A.Helpers.Types;

namespace Unilab2021A.Fields
{
        class StageJson
        {
        public string StageName { get; set; }
        public List<int> StartPosition { get; set; }
        public List<Cell> Path { get; set; } = new List<Cell>();
        }

    class Cell
    {
        public ImageType Image { get; set; }
        public DirectionType Direction { get; set; }
        public List<int> Position { get; set; }
    }
}
