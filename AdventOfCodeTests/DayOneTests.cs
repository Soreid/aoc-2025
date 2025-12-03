using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDayOne.Models;

namespace AdventOfCodeTests
{
    public class DayOneTests
    {
        [Theory]
        [InlineData(new string[] { "L50" }, 1)]
        [InlineData(new string[] { "R50" }, 1)]
        public void LandOnZeroCountsOnce(string[] instructions, int target)
        {
            DialModel dial = new(50, 100);

            foreach (string instruction in instructions)
            {
                InstructionModel i = new(instruction);
                dial.Spin(i.TurnDistance);
            }

            Assert.Equal(dial.ZeroClicks, target);
        }
    }
}
