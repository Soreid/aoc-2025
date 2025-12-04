using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayTwo
{
    public class DayTwo(string input)
    {
        string[] Inputs { get; set; } = input.Split(',');

        public string[]? SplitString(string number)
        {
            if(number.Length % 2 == 1)
            {
                return null;
            }

            int half = number.Length / 2;

            return [number.Substring(0, half), number.Substring(half)];
        }

        public bool HalvesMatch(string number)
        {
            string[]? parts = SplitString(number);

            if (parts == null)
            {
                return false;
            }

            return parts[0] == parts[1];
        }
    }
}
