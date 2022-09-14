using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Models
{
    public class Row
    {
        public string Name;
        public int ValueA;
        public int ValueB;

        public int AbsDiff
        {
            get
            {
                return Math.Abs(ValueB - ValueA);
            }
        }
    }

    public class Range
    {
        public int From;
        public int Length;

        public static Range New(int from, int length)
        {
            return new Range { From = from, Length = length };
        }
    }
}
