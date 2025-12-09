using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayFive
{
    public class DayFive
    {
        internal List<long[]> Ranges { get; private set; } = new();
        internal List<long> Ids { get; private set; } = new();

        public DayFive(string[] input)
        {
            bool addRanges = true;

            foreach(string i in input)
            {
                if (string.IsNullOrWhiteSpace(i))
                {
                    addRanges = !addRanges;
                }
                else if (addRanges)
                {
                    Ranges.Add(GetRange(i));
                }
                else
                {
                    Ids.Add(long.Parse(i));
                }
            }
        }

        internal long[] GetRange(string range)
        {
            long[] output = new long[2];

            string[] numbers = range.Split('-');
            for (int i = 0; i < numbers.Length; i++)
            {
                output[i] = Int64.Parse(numbers[i]);
            }

            return output;
        }

        internal bool IsWithinRange(long target, List<long[]> ranges)
        {
            foreach (long[] range in ranges)
            {
                if (range[0] <= target && range[1] >= target)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetFreshCount()
        {
            int freshCount = 0;

            foreach (long id in Ids)
            {
                if (IsWithinRange(id, Ranges))
                {
                    freshCount++;
                }
            }

            return freshCount;
        }

        public int GetExpiredCount()
        {
            return Ids.Count - GetFreshCount();
        }
    }
}
