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
                    List<string[]> sets = new();

                    for (int i = 1; i <= value.Length; i++)
                    {
                        if (SplitString(value, i) != null)
                        {
                            sets.Add(SplitString(value, i));
                        }
                    }

                    foreach (string[] set in sets)
                    {
                        if (PartsAreEqual(set))
                        {
                            output += Int64.Parse(value);
                            break;
                        }
                    }

                }
            }

            return output;
        }

        internal string[]? SplitString(string number, int parts)
        {
            if(number.Length % parts != 0)
            {
                return null;
            }

            string[] output = new string[parts];
            int length = number.Length / parts;

            for (int i = 0; i < parts; i++)
            {
                output[i] = number.Substring(i * length, length);
            }

            return output;
        }

        internal bool PartsAreEqual(string[] group)
        {
            if (group.Length == 1)
            {
                return false;
            }

            string match = group[0];
            foreach (string x in group)
            {
                if (x != match)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
