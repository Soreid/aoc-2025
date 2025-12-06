using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayFour.Models
{
    internal class GridModel
    {
        internal GridModel(string[] data)
        {
            char[,] points = new char[data.Length,data[0].Length];

            for (int i = 0; i < points.GetLength(0); i++)
            {
                for (int j = 0; j < points.GetLength(1); j++)
                {
                    points[i, j] = data[i][j];
                }
            }

            Points = points;
        }

        internal char[,] Points { get; private set; }

        internal char[] GetNeighbors(int[] pos, int radius)
        {
            int x = pos[0]; 
            int y = pos[1];

            List<char> neighbors = new List<char>();

            for (int i = x - radius; i <= x + radius; i++)
            {
                for (int j = y - radius; j <= y + radius; j++)
                {
                    if ((i >= 0 && i < Points.GetLength(0)) && 
                        (j >= 0 && j < Points.GetLength(1)))
                    {
                        if (i != x || j != y)
                        {
                            neighbors.Add(Points[i, j]);
                        }
                    }
                }
            }

            return neighbors.ToArray();
        }

        public void Remove(int[] pos)
        {
            Points[pos[0], pos[1]] = '.';
        }
    }
}
