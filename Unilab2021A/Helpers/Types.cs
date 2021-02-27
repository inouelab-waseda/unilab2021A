using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unilab2021A.Helpers
{
    public static class Types
    {
        public enum Instruction { IfCode, ForCode, WhileCode, Forward, TurnRight, TurnLeft, End, Stop, None }
        public enum Direction { None, Up, Down, Right, Left, Forward, Backward }
        public enum Obj { Wall, Enemy, Road, None }
    }
}
