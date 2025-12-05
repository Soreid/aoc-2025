using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayFour.Models
{
    internal class GridModel(string[] data)
    {
        internal char[,] Points { get; private set; }

        internal char[] GetNeighbors(int[] pos, int radius)
        {
            throw new NotImplementedException();
        }
    }
}
