using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unilab2021A.Helpers;
using Unilab2021A.Interfaces;

namespace Unilab2021A.Objects
{
    class Person : IPerson
    {
        private int x, y;
        public int X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Types.Direction Direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Image[] images { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
