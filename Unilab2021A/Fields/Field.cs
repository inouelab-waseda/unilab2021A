using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unilab2021A.Objects;
using Action = Unilab2021A.Objects.Action;

namespace Unilab2021A.Fields
{
    class Field
    {
        public Person Person { get; set; }
        public List<Action> Actions { get; set; }
    }
}
