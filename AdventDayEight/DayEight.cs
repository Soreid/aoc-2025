using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDayEight.Models;

namespace AdventDayEight
{
    public class DayEight
    {
        internal JunctionModel[] Junctions { get; private set; }
        internal Dictionary<int[], double> Distances { get; private set; } = new();
        internal Dictionary<int, int> CircuitSizes { get; private set; } = new();

        public DayEight(string[] inputs)
        {
            Junctions = new JunctionModel[inputs.Length];
            for(int i = 0; i < Junctions.Length; i++)
            {
                Junctions[i] = CreateJunction(inputs[i]);
                Junctions[i].Circuit = i;
                CircuitSizes.Add(i, 1);
                for (int j = 0; j < i; j++)
                {
                    Distances.Add([i, j], CalculateDistance(Junctions[i], Junctions[j]));
                }
            }
        }

        public long ConnectNearestJunctions()
        {
            Dictionary<int[], double> nearestBoxes = Distances.OrderBy(x => x.Value).ToDictionary<int[], double>();
            int[] lastPair = new int[2];
            foreach (KeyValuePair<int[], double> boxPair in nearestBoxes)
            {
                ConnectJunctions(Junctions[boxPair.Key[0]], Junctions[boxPair.Key[1]]);
                lastPair = boxPair.Key;
                if (CircuitSizes.Count == 1)
                {
                    break;
                }
            }

            return Junctions[lastPair[0]].X * Junctions[lastPair[1]].X;
        }

        public void ConnectNearestJunctions(int connections)
        {
            int current = 0;
            Dictionary<int[], double> nearestBoxes = Distances.OrderBy(x => x.Value).ToDictionary<int[], double>();
            foreach (KeyValuePair<int[], double> boxPair in nearestBoxes)
            {
                if (current == connections)
                {
                    break;
                }
                ConnectJunctions(Junctions[boxPair.Key[0]], Junctions[boxPair.Key[1]]);
                current++;
            }
        }

        public long GetProductOfCircuits(int circuits)
        {
            long output = 0;
            Dictionary<int, int> largestCircuits = CircuitSizes.OrderByDescending(x => x.Value).ToDictionary<int, int>();
            int[] prodCircuits = largestCircuits.Values.Take(circuits).ToArray();
            for (int i = 0; i < prodCircuits.Length; i++)
            {
                if (output == 0)
                {
                    output = prodCircuits[i];
                }
                else
                {
                    output *= prodCircuits[i];
                }
            }
            return output;
        }

        internal JunctionModel CreateJunction(string coordinates)
        {
            string[] coords = coordinates.Split(',');
            return new(long.Parse(coords[0]), long.Parse(coords[1]), long.Parse(coords[2]));
        }

        internal double CalculateDistance(JunctionModel box1, JunctionModel box2) =>
            Math.Sqrt(Math.Pow((box1.X - box2.X), 2) + 
                      Math.Pow((box1.Y - box2.Y), 2) + 
                      Math.Pow((box1.Z - box2.Z), 2));

        internal void ConnectJunctions(JunctionModel box1, JunctionModel box2)
        {
            CircuitSizes.Remove(box2.Circuit);
            int c = box1.Circuit;
            JunctionModel[] additions = Junctions.Where(x => x.Circuit == box2.Circuit).ToArray();
            foreach (JunctionModel addition in additions)
            {
                addition.Circuit = c;
            }
            if (CircuitSizes.ContainsKey(c))
            {
                CircuitSizes[c] += additions.Length;
            }
            else
            {
                CircuitSizes.Add(c, Junctions.Where(x => x.Circuit == c).Count());
            }
        }
    }
}
