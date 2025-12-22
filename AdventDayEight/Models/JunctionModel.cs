using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayEight.Models
{
    public class JunctionModel(long x, long y, long z)
    {
        public long X { get; private set; } = x;
        public long Y { get; private set; } = y;
        public long Z { get; private set; } = z;
        public int Circuit { get; set; }
    }
}
