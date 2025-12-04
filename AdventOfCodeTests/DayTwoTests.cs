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
        [InlineData("11", new string[] { "1", "1" })]
        [InlineData("29275383", new string[] { "2927", "5383" })]
        [InlineData("83753", null)]
        public void SeparatesNumberCorrectly(string input, string[]? expected)
        {
            DayTwo dayTwo = new(input);
            string[]? result = dayTwo.SplitString(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("6776", false)]
        [InlineData("38250", false)]
        [InlineData("124124", true)]
        [InlineData("98539853", true)]
        public void HalvesMatchCorrectly(string input, bool expected)
        {
            DayTwo dayTwo = new(input);
            bool result = dayTwo.HalvesMatch(input);

            Assert.Equal(expected, result);
        }
    }
}
