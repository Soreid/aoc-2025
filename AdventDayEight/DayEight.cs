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
        internal Dictionary<int, int> CircuitSizes { get; private set; }

        public DayEight(string[] inputs)
        {
            Junctions = new JunctionModel[inputs.Length];
            for(int i = 0; i < Junctions.Length; i++)
            {
                Junctions[i] = CreateJunction(inputs[i]);
                Junctions[i].Circuit = i;
            }
        }

        public long ConnectJunctions(int connections)
        {
            throw new NotImplementedException();
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
            if (CircuitSizes.ContainsValue(c))
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
