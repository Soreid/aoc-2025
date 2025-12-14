using AdventDaySix.Models;
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
        internal List<ProblemModel> Problems { get; set; } = new();

        public DaySix(string[] inputs)
        {
            List<string> cols = new();
            for (int i = inputs[0].Length - 1; i >= 0; i--)
            {
                string col = GetColumn(inputs, i);
                if (string.IsNullOrWhiteSpace(col))
                {
                    Problems.Add(ConstructProblem(cols));
                    cols.Clear();
                }
                else
                {
                    cols.Add(col);
                }
            }

            Problems.Add(ConstructProblem(cols));
        }

        public long SolveHomework()
        {
            long output = 0;

            foreach (ProblemModel problem in Problems)
            {
                output += problem.Calc();
            }

            return output;
        }

        internal string GetColumn(string[] inputs, int index)
        {
            string output = "";

            for (int i = 0; i < inputs.Length; i++)
            {
                output += inputs[i][index];
            }

            return output;
        }
        
        internal ProblemModel ConstructProblem(List<string> input)
        {
            ProblemModel problem = new();

            for(int i = 0; i < input.Count; i++)
            {
                string num = input[i];
                if (num.Contains('+') || num.Contains('*'))
                {
                    problem.Operator = num.Last();
                    num = num.Remove(num.Length - 1);
                }
                problem.Numbers.Add(int.Parse(num.Trim()));
            }

            return problem;
        }
    }
}
