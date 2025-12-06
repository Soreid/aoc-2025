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

        internal bool IsAccessible(int[] pos, char[] blockers, int threshold, int radius)
        {
            int blockCount = 0;

            char[] chars = Grid.GetNeighbors(pos, radius);
            foreach(char c in chars)
            {
                if (blockers.Any(x => x == c))
                {
                    blockCount++;
                }
            }

            return blockCount < threshold;
        }

        public int GetAccessibleCount(char[] blockers, int threshold, int radius)
        {
            int accessiblePoints = 0;

            for (int i = 0; i < Grid.Points.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.Points.GetLength(1); j++)
                {
                    if (Grid.Points[i, j] == '@' && IsAccessible([i, j], blockers, threshold, radius))
                    {
                        accessiblePoints++;
                    }
                }
            }

            return accessiblePoints;
        }
    }
}