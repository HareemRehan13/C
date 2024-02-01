using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class hello<abc>
    {
        abc variable;
        public hello(abc a)        {
            this.variable = a;
        }
        public abc meth()        {
            return variable;
        }
    }
}
