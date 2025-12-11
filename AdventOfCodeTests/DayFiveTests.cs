using AdventDayFive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTests
{
    public class DayFiveTests
    {
        [Theory]
        [InlineData("3-6", new long[] { 3, 6 })]
        [InlineData("95-1492", new long[] { 95, 1492 })]
        [InlineData("1-2", new long[] { 1, 2 })]
        public void GetsRangeCorrectly(string input, long[] expected)
        {
            DayFive dayFive = new([""]);

            long[] actual = dayFive.GetRange(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetSingleData => new List<object[]>
        {
            new object[] { 6, new List<long[]> { new long[] { 3, 5 }, new long[] { 7, 11 } }, false },
            new object[] { 14, new List<long[]> { new long[] { 4, 9 }, new long[] { 7, 14 } }, true },
            new object[] { 8, new List<long[]> { new long[] { 1, 4 }, new long[] { 8, 80 }, new long[] { 14, 86 }, new long[] { 77, 83 } }, true }
        };


        [Theory]
        [MemberData(nameof(GetSingleData))]
        public void IdentifiesSingleExpiryCorrectly(int target, List<long[]> ranges, bool expected)
        {
            DayFive dayFive = new([""]);

            bool actual = dayFive.IsWithinRange(target, ranges);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new long[] { 10, 20 }, 11)]
        [InlineData(new long[] { 44, 44 }, 1)]
        [InlineData(new long[] { 1, 1001 }, 1001 )]
        public void SingleRangeCountIsCorrect(long[] range, int expected)
        {
            DayFive dayFive = new([""]);

            int actual = dayFive.GetIdsInRange(range);

            Assert.Equal(expected, actual);
        }
    }
}
