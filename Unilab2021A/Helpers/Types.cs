using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unilab2021A.Helpers
{
    public static class Types
    {
        public enum ImageType { Others, Road, Sword, Enemy }
        public enum DirectionType { None, Up, Right, Down, Left }

        public enum ActionBlockType { Up, Right, Left, Blue, Red, Yellow, One, Two }
    }
}
