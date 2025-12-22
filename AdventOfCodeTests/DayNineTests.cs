using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDayNine;

namespace AdventOfCodeTests
{
    public class DayNineTests
    {
        public static IEnumerable<object[]> CoordInputs => new List<object[]>
        {
            new object[] { new string[] { "7,4" }, new int[,] { { 7, 4 } } },
            new object[] { new string[] { "9,0", "82,1" }, new int[,] { { 9, 0 }, { 82, 1 } } },
            new object[] { new string[] { "5277,25", "3628,835", "203,3" }, new int[,] { { 5277, 25 }, { 3628, 835 }, { 203, 3 } } }
        };

        [Theory]
        [MemberData(nameof(CoordInputs))]
        public void CoordsConvertCorrectly(string[] inputs, int[,] expected)
        {
            DayNine dayNine = new(inputs);
            Assert.Equal(expected, dayNine.RedTiles);
        }

        public static IEnumerable<object[]> RectCoords => new List<object[]>
        {
            new object[] { new int[,] { { 1, 1 } }, new int[,] { { 4, 4 } }, 16 },
            new object[] { new int[,] { { 3, 5 } }, new int[,] { { 3, 7 } }, 3 },
            new object[] { new int[,] { { 6, 9 } }, new int[,] { { 8, 2 } }, 24 },
            new object[] { new int[,] { { 50, 12 } }, new int[,] { { 42, 91 } }, 720 }
        };

        [Theory]
        [MemberData(nameof(RectCoords))]
        public void RectangleAreaIsCalculated(int[,] corner1, int[,] corner2, long expected)
        {
            DayNine dayNine = new([]);

            long actual = dayNine.GetRectArea(corner1, corner2);

            Assert.Equal(expected, actual);
        }
    }
}
