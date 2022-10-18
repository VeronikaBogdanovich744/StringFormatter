using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StringFormatter
{
    internal class StringFormatter : IStringFormatter
    {
        public static readonly StringFormatter Shared = new StringFormatter();
        public string Format(string template, object target)
        {

            string[] templateWords = template.Split('{','}',' ');
            throw new NotImplementedException();
        }
    }
}
