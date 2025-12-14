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
        [Theory]
        [InlineData("24 25 26", new string[] { "24", "25", "26" })]
        [InlineData("7 12 738 9238 26743", new string[] { "7", "12", "738", "9238", "26743" })]
        [InlineData("1", new string[] { "1" })]
        public void SingleSpaceSplitsProperly(string input, string[] expected)
        {
            DaySix daySix = new([""]);

            string[] actual = daySix.SplitLine(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("24   25 26 ", new string[] { "24", "25", "26" })]
        [InlineData(" 7 12  738   9238  26743 ", new string[] { "7", "12", "738", "9238", "26743" })]
        [InlineData("1 ", new string[] { "1" })]
        public void MultipleSpacsSplitProperly(string input, string[] expected)
        {
            DaySix daySix = new([""]);

            string[] actual = daySix.SplitLine(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new long[] { 6, 14, 24 }, "+", 44)]
        [InlineData(new long[] { 33, 29, 1 }, "-", 3)]
        [InlineData(new long[] { 3, 6, 2 }, "*", 36)]
        [InlineData(new long[] { 24, 2, 2 }, "/", 6)]
        public void ColumnsCalculateCorrectly(long[] input, string op, long expected)
        {
            DaySix daySix = new([""]);

            long actual = daySix.CalculateColumn(input, op);

            Assert.Equal(expected, actual);
        }
        

        [Theory]
        [InlineData(new string[] { "25 36 47", "92  75  20 ", "1   89   28 ", "+    *   + " }, 0, new string[] { "25", "92", "1", "+" })]
        [InlineData(new string[] { "25 36 47", "92  75  20 ", "1   89   28 ", "+    *   + " }, 1, new string[] { "36", "75", "89", "*" })]
        [InlineData(new string[] { "25 36 47", "92  75  20 ", "1   89   28 ", "+    *   + " }, 2, new string[] { "47", "20", "28", "+" })]
        public void ColumnNumsReturnProperly(string[] inputs, int index, string[] expected)
        {
            DaySix daySix = new(inputs);

            string[] actual = daySix.GetColumnFromSet(daySix.ProblemSets, index);

            Assert.Equal(expected, actual);
        }
    }
}
