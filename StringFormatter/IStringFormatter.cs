using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFormatter
{
    internal interface IStringFormatter
    {
        string Format(string template, object target);
    }
}
