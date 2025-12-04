using AdventDayTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayTwo
{
    public class DayTwo(string input)
    {
        string[] Ranges { get; set; } = input.Split(',');

        public long AddInvalidIds()
        {
            long output = 0;

            foreach(string range in Ranges)
            {
                SectionModel section = new(range);

                foreach(string value in section.GetValues())
                {
                    if(HalvesMatch(value))
                    {
                        output += Int64.Parse(value);
                    }
                }
            }

            return output;
        }

        internal string[]? SplitString(string number)
        {
            if(number.Length % 2 == 1)
            {
                return null;
            }

            int half = number.Length / 2;

            return [number.Substring(0, half), number.Substring(half)];
        }

        internal bool HalvesMatch(string number)
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
