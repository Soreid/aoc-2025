using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDaySix
{
    internal class DaySix
    {
        internal string[] Inputs;
        internal string[][] ProblemSets;

        public DaySix(string[] inputs)
        {
            Inputs = inputs;
            ProblemSets = new string[inputs.Length][];

            for (int i = 0; i < inputs.Length; i++)
            {
                ProblemSets[i] = SplitLine(inputs[i]);
            }
        }

        public long SolveHomework(string[] input)
        {
            throw new NotImplementedException();
        }

        internal string[] SplitLine(string line)
        {
            throw new NotImplementedException();
        }

        internal string[] GetColumnFromSet(string[][] set, int column)
        {
            throw new NotImplementedException();
        }

        internal long CalculateColumn(long[] nums, string op)
        {
            throw new NotImplementedException();
        }
    }
}
