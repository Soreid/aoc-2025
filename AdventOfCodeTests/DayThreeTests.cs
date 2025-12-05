using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDayThree; 

namespace AdventOfCodeTests
{
    public class DayThreeTests
    {
        [Theory]
        [InlineData("9876111", 2, "98")]
        [InlineData("1211419", 2, "49")]
        [InlineData("3852639618", 3, "968")]
        public void GetsCorrectArrangement(string input, int buffer, string expected)
        {
            DayThree dayThree = new(new [] { "" });
            string result = dayThree.FindLargestSet(input, 0, buffer);
            Assert.Equal(expected, result);
        }
    }
}
