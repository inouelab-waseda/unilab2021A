﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unilab2021A.Helpers
{
    public static class Types
    {
        public enum ImageType { Others, Road, Sword, Enemy, Blue, Red, Yellow }
        public enum DirectionType { Up, Right, Down, Left }
        public enum BlockType { GoStraight, TurnRight, TurnLeft, Blue, Red, Yellow, First, Second }
        public enum ActionBlockType { None, GoStraight, TurnRight, TurnLeft, First, Second }
        public enum ConditionBlockType { None, Blue, Red, Yellow }
    }
}
