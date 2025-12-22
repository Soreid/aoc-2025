using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayNine
{
    public class DayNine
    {
        public int[][] RedTiles;
        public DayNine(string[] inputs)
        {
            RedTiles = new int[inputs.Length][];
            for(int i = 0; i < inputs.Length; i++)
            {
                string[] strNums = inputs[i].Split(',');
                RedTiles[i] = [int.Parse(strNums[0]), int.Parse(strNums[1])];
            }
        }

        public long GetLargestArea()
        {
            long max = 0;

            for (int i = 0; i < RedTiles.Length; i++)
            {
                for (int j = 0; j < RedTiles.Length; j++)
                {
                    long area = GetRectArea(RedTiles[i], RedTiles[j]);
                    if (area > max)
                    {
                        max = area;
                    }
                }
            }

            return max;
        }

        internal long GetRectArea(int[] corner1, int[] corner2)
        {
            long x = Math.Abs(corner1[0] - corner2[0]) + 1;
            long y = Math.Abs(corner1[1] - corner2[1]) + 1;
            long product = x * y;
            return product;
        }
    }
}
