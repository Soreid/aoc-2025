using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDaySix;

namespace AdventOfCodeTests
{
    public class DaySixTests
    {
        public static string[] inputs = new string[]
        {
            "123 456 7891  1  32",
            "045 061 789   2   1",
            "  1   2 10   345  3",
            "+   *   +    *   + "
        };

        [Theory]
        [InlineData(0, "10 +")]
        [InlineData(3, "    ")]
        [InlineData(6, "612 ")]
        [InlineData(13, "  3*")]
        public void CorrectStringColumn(int index, string expected)
        {
            DaySix daySix = new(inputs);

            string actual = daySix.GetColumn(inputs, index);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ObjectsParseCorrectly()
        {
            DaySix daySix = new(inputs);

            Assert.Equal(5, daySix.Problems.Count);
        }

        [Theory]
        [InlineData(0, 216)]
        [InlineData(1, 1860)]
        [InlineData(2, 1751)]
        public void ProblemsCalculateProperly(int problem, long expected)
        {
            DaySix daySix = new(inputs);

            Assert.Equal(expected, daySix.Problems[problem].Calc());
        }
    }
}
