using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDayEight;
using AdventDayEight.Models;

namespace AdventOfCodeTests
{
    public class DayEightTests
    {
        [Theory]
        [InlineData("3,4,5", "6,7,8", 5.1962)]
        [InlineData("1,1,1", "1,1,2", 1.0000)]
        [InlineData("415,312,416", "813,218,582", 441.3570)]
        public void ShortestDistanceIsCalculated(string box1, string box2, double expected)
        {
            DayEight dayEight = new([]);

            double actual = dayEight.CalculateDistance(dayEight.CreateJunction(box1), dayEight.CreateJunction(box2));

            Assert.Equal(expected, actual, 4);
        }
    }
}
