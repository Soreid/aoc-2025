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
        [InlineData("3-6", new int[] { 3, 6 })]
        [InlineData("95-1492", new int[] { 95, 1492 })]
        [InlineData("1-2", new int[] { 1, 2 })]
        public void GetsRangeCorrectly(string input, int[] expected)
        {
            DayFive dayFive = new("");

            int[] actual = dayFive.GetRange(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetSingleData => new List<object[]>
        {
            new object[] { 6, new List<int[]> { new int[] { 3, 5 }, new int[] { 7, 11 } }, false },
            new object[] { 14, new List<int[]> { new int[] { 4, 9 }, new int[] { 7, 14 } }, true },
            new object[] { 8, new List<int[]> { new int[] { 1, 4 }, new int[] { 8, 80 }, new int[] { 14, 86 }, new int[] { 77, 83 } }, true }
        };


        [Theory]
        [MemberData(nameof(GetSingleData))]
        public void IdentifiesSingleExpiryCorrectly(int target, List<int[]> ranges, bool expected)
        {
            DayFive dayFive = new("");

            bool actual = dayFive.IsWithinRange(target, ranges);

            Assert.Equal(expected, actual);
        }
    }
}
