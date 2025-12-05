using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AdventDayTwo;

namespace AdventOfCodeTests
{
    public class DayTwoTests
    {
        [Theory]
        [InlineData("11", 2, new string[] { "1", "1" })]
        [InlineData("29275383", 2, new string[] { "2927", "5383" })]
        [InlineData("83753", 2, null)]
        public void SeparatesNumberCorrectly(string input, int parts, string[]? expected)
        {
            DayTwo dayTwo = new(input);
            string[]? result = dayTwo.SplitString(input, parts);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "4", "4", "4", "4" }, true)]
        [InlineData(new string[] { "4", "4", "5", "4" }, false)]
        [InlineData(new string[] { "25034" }, false)]
        [InlineData(new string[] { "234", "235", "236" }, false)]
        public void PartsMatchCorrectly(string[] input, bool expected)
        {
            DayTwo dayTwo = new("");
            bool result = dayTwo.PartsAreEqual(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("23-25", 0)]
        [InlineData("32-34", 33)]
        [InlineData("41-44,44-62", 143)]
        public void InvalidIdsAddCorrectly(string input, int expected)
        {
            DayTwo dayTwo = new(input);
            long result = dayTwo.AddInvalidIds();

            Assert.Equal(result, expected);
        }
    }
}
