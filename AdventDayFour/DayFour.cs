using AdventDayFour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayFour
{
    public class DayFour(string[] data)
    {
        internal GridModel Grid { get; private set; } = new(data);

        internal bool IsAccessible(char[] blockers, int threshold, int radius)
        {
            throw new NotImplementedException();
        }

        public int GetAccessibleCount(char[] blockers, int threshold, int radius)
        {
            throw new NotImplementedException();
        }
    }
}
