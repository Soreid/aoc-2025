using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDaySix
{
    public class DaySix
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

        public long SolveHomework()
        {
            long output = 0;

            for (int i = 0; i < ProblemSets[0].Length; i++)
            {
                string[] problem = GetColumnFromSet(ProblemSets, i);

                long[] nums = new long[problem.Length - 1];
                for (int j = 0; j < nums.Length; j++)
                {
                    nums[j] = long.Parse(problem[j]);
                }

                output += CalculateColumn(nums, problem.Last());
            }

            return output;
        }

        internal string[] SplitLine(string line)
        {
            List<string> cells = new List<string>();
            string cell = "";

            foreach (char c in line.Trim())
            {
                if (!char.IsWhiteSpace(c))
                {
                    cell += c;
                }
                else if (char.IsWhiteSpace(c) && !string.IsNullOrWhiteSpace(cell))
                {
                    cells.Add(cell);
                    cell = "";
                }
            }

            if (!string.IsNullOrWhiteSpace(cell))
            {
                cells.Add(cell);
            }

            return cells.ToArray();
                
        }

        internal string[] GetColumnFromSet(string[][] set, int col)
        {
            string[] output = new string[set.Length];
            for (int i = 0; i < set.Length; i++)
            {
                output[i] = set[i][col];
            }
            return output;
        }

        internal long CalculateColumn(long[] nums, string op)
        {
            long output = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                switch (op)
                {
                    case "+":
                        output += nums[i];
                        break;
                    case "*":
                        output *= nums[i];
                        break;
                    case "-":
                        output -= nums[i];
                        break;
                    case "/":
                        output /= nums[i];
                        break;
                    default:
                        throw new ArgumentException($"Calculation operation '{op}' not recognized.");
                }
            }

            return output;
        }
    }
}
