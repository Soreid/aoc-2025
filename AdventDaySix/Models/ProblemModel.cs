using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDaySix.Models
{
    internal class ProblemModel
    {
        public List<int> Numbers { get; private set; } = new();
        public char Operator { get; set; }
        public long Calc()
        {
            long output = Numbers[0];

            if (Operator == '+')
            {
                for (int i = 1; i < Numbers.Count; i++) 
                {
                    output += Numbers[i];
                }
            }

            if (Operator == '*')
            {
                for (int i = 1; i < Numbers.Count; i++)
                {
                    output *= Numbers[i];
                }
            }

            return output;
        }
    }
}
