using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayNine
{
    public class DayNine
    {
        public int[,] RedTiles;
        public DayNine(string[] inputs)
        {
            RedTiles = new int[inputs.Length,2];
            for(int i = 0; i < inputs.Length; i++)
            {
                string[] strNums = inputs[i].Split(',');
                RedTiles[i, 0] = int.Parse(strNums[0]);
                RedTiles[i, 1] = int.Parse(strNums[1]);
            }
        }

        public long GetLargestArea()
        {
            throw new NotImplementedException();
        }

        internal long GetRectArea(int[,] corner1, int[,] corner2)
        {
            throw new NotImplementedException();
        }
    }
}
