using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unilab2021A.Helpers;

namespace Unilab2021A.Objects
{
    class Person
    {
        private int x, y;
        private Graphics g;
        public Person()
        {
            X = 0;
            Y = 0;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Types.Direction Direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Image[] images { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
