using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayFive
{
    public class DayFive
    {
        internal List<int[]> Ranges { get; private set; } = new();
        internal List<int> Ids { get; private set; } = new();

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
                    Ids.Add(int.Parse(i));
                }
            }
        }

        internal int[] GetRange(string range)
        {
            int[] output = new int[2];

            string[] numbers = range.Split('-');
            for (int i = 0; i < numbers.Length; i++)
            {
                output[i] = int.Parse(numbers[i]);
            }

            return output;
        }

        internal bool IsWithinRange(int target, List<int[]> ranges)
        {
            foreach (int[] range in ranges)
            {
                if (range[0] <= target && range[1] >= target)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetExpiredCount()
        {
            int expiredCount = 0;

            foreach (int id in Ids)
            {
                if (IsWithinRange(id, Ranges))
                {
                    expiredCount++;
                }
            }

            return expiredCount;
        }
    }
}
