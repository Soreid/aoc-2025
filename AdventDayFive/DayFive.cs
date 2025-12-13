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

        public long GetTotalFreshCount()
        {
            return GetTotalIdCount(Ranges);
        }

        public int GetExpiredCount()
        {
            return Ids.Count - GetFreshCount();
        }

        internal long GetTotalIdCount(List<long[]> ranges)
        {
            long total = 0;
            long current = 0;

            ranges = ranges.OrderBy(x => x[0]).ToList();

            for (int i = 0; i < ranges.Count; i++)
            {
                if (ranges[i][1] > current)
                {
                    AdjustRangeMinimum(i, ranges[i], ranges);
                    total += GetIdsInRange(ranges[i]);
                    current = ranges[i][1];
                }
            }

            return total;
        }

        internal long GetIdsInRange(long[] range)
        {
            return range[1] - range[0] + 1;
        }        

        internal void AdjustRangeMinimum(int start, long[] range, List<long[]> ranges)
        {
            for (int i = start + 1; i < ranges.Count; i++)
            {
                if (ranges[i][0] <= range[1])
                {
                    if (ranges[i][1] > range[1])
                    {
                        ranges[i][0] = range[1] + 1;
                    }
                }
            }
        }

        
    }
}
