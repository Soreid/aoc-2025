using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayThree
{
    public class DayThree(string[] input)
    {
        string[] Inputs = input;

        public int GetTotalJoltage()
        {
            int total = 0;

            foreach (string input in Inputs)
            {
                string joltage = FindLargestSet(input, 0, 1);
                total += int.Parse(joltage);
            }

            return total;
        }

        internal string FindLargestSet(string input, int start, int buffer)
        {
            int index = GetLargestIndex(input, start, buffer);
            string output = input[index].ToString();
            if (buffer > 0)
            {
                output += FindLargestSet(input, index + 1, buffer - 1);
            }
            return output;
        }

        internal int GetLargestIndex(string input, int start, int buffer)
        {
            int index = start;
            for (int i = start; i < input.Length - buffer; i++)
            {
                if (input[i] > input[index])
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
