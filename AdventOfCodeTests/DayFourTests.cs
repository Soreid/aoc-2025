using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDayFour;

namespace AdventOfCodeTests
{
    public class DayFourTests
    {
        public static string[] DataGrid = new string[]  
            { ".@@@..@",
              ".@@@...",
              "@@@@...",
              "....@..",
              "..@....",
              ".@@@..@",
              "..@...." };
        

        public static IEnumerable<object[]> PointsData => new List<object[]>
        {
            new object[] { new string[] { ".@." }, new char[,] { { '.', '@', '.' } } },
            new object[] { new string[] { ".@.", "@.@", "..@" }, new char[,] { { '.', '@', '.' }, { '@', '.', '@' }, { '.', '.', '@' } } },
            new object[] { new string[] { "@@@@@", ".....", "@@@.@" }, new char[,] { { '@', '@', '@', '@', '@' }, { '.', '.', '.', '.', '.' }, { '@', '@', '@', '.', '@' } } }
        };

        [Theory]
        [MemberData(nameof(PointsData))]
        public void GridPointConvertsCorrectly(string[] data, char[,] expected)
        {
            DayFour dayFour = new(data);
            char[,] actual = dayFour.Grid.Points;

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> NeighborData => new List<object[]>
        {
            new object[] { DataGrid, new int[] { 0, 0 }, 1, new char[] { '@', '.', '@' } },
            new object[] { DataGrid, new int[] { 2, 1 }, 1, new char[] { '@', '@', '@', '@', '@', '@', '@', '@' } },
            new object[] { DataGrid, new int[] { 6, 6 }, 1, new char[] { '.', '@', '.' } },
            new object[] { DataGrid, new int[] { 5, 5 }, 2, new char[] { '.', '@', '.', '.', '.', '.', '.', '.', '@', '.', '.', '@', '.', '.', '.', '.' } }
        };

        [Theory]
        [MemberData(nameof(NeighborData))]
        public void GetsCorrectNeighborsList(string[] data, int[] pos, int radius, char[] expected)
        {
            DayFour dayFour = new(data);
            char[] actual = dayFour.Grid.GetNeighbors(pos, radius);

            Assert.Equal(expected.Order(), actual.Order());
        }

        public static IEnumerable<object[]> AccessibleData => new List<object[]>
        {
            new object[] { DataGrid, new int[] { 0, 0 }, new char[] { '@' }, 4, 1, true },
            new object[] { DataGrid, new int[] { 2, 1 }, new char[] { '@' }, 4, 1, false },
            new object[] { DataGrid, new int[] { 1, 2 }, new char[] { '@' }, 4, 1, false },
            new object[] { DataGrid, new int[] { 1, 2 }, new char[] { '@' }, 5, 1, true },
            new object[] { DataGrid, new int[] { 2, 5 }, new char[] { '@' }, 4, 1, false },
            new object[] { DataGrid, new int[] { 2, 5 }, new char[] { '@' }, 5, 1, true },
            new object[] { DataGrid, new int[] { 2, 5 }, new char[] { '@' }, 5, 2, false },
            new object[] { DataGrid, new int[] { 0, 6 }, new char[] { '@' }, 4, 2, false }
        };

        [Theory]
        [MemberData(nameof(NeighborData))]
        public void GetsCorrectAccessibleCount(string[] data, int[] pos, char[] blockers, int threshold, int radius, bool expected)
        {
            DayFour dayFour = new(data);
            bool actual = dayFour.IsAccessible(pos, blockers, threshold, radius);
            Assert.Equal(expected, actual);
        }
    }
}
