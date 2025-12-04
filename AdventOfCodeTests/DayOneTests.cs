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
        [InlineData(new string[] { "R50", "L40", "R40" }, 2)]
        public void LandOnZeroCountsOnce(string[] instructions, int target)
        {
            DialModel dial = new(50, 100);

            foreach (string instruction in instructions)
            {
                InstructionModel i = new(instruction);
                dial.Spin(i.TurnDistance);
            }

            Assert.Equal(target, dial.ZeroClicks);
        }

        [Theory]
        [InlineData(new string[] { "R100" }, 1)]
        [InlineData(new string[] { "L100" }, 1)]
        [InlineData(new string[] { "L100", "R100" }, 2)]
        public void FullRotationCountsOnce(string[] instructions, int target)
        {
            DialModel dial = new(50, 100);

            foreach (string instruction in instructions)
            {
                InstructionModel i = new(instruction);
                dial.Spin(i.TurnDistance);
            }

            Assert.Equal(target, dial.ZeroClicks);
        }

        [Theory]
        [InlineData(99, 1)]
        [InlineData(98, 1)]
        [InlineData(97, 0)]
        public void DetectsSmallRightRotations(int startNumber, int target)
        {
            DialModel dial = new(startNumber, 100);

            InstructionModel i = new("R2");
            dial.Spin(i.TurnDistance);

            Assert.Equal(target, dial.ZeroClicks);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 0)]
        public void DetectsSmallLeftRotations(int startNumber, int target)
        {
            DialModel dial = new(startNumber, 100);

            InstructionModel i = new("L2");
            dial.Spin(i.TurnDistance);

            Assert.Equal(target, dial.ZeroClicks);
        }


        [Theory]
        [InlineData(90, 5)]
        [InlineData(0, 4)]
        [InlineData(10, 4)]
        public void DetectsLargeRightRotations(int startNumber, int target)
        {
            DialModel dial = new(startNumber, 100);

            InstructionModel i = new("R410");
            dial.Spin(i.TurnDistance);

            Assert.Equal(target, dial.ZeroClicks);
        }

        [Theory]
        [InlineData(90, 4)]
        [InlineData(0, 4)]
        [InlineData(10, 5)]
        public void DetectsLargeLeftRotations(int startNumber, int target)
        {
            DialModel dial = new(startNumber, 100);

            InstructionModel i = new("L410");
            dial.Spin(i.TurnDistance);

            Assert.Equal(target, dial.ZeroClicks);
        }

        [Theory]
        [InlineData(new string[] { "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82" }, 6)]
        public void CorrectResultFromSequence(string[] instructions, int target)
        {
            DialModel dial = new(50, 100);

            foreach (string instruction in instructions)
            {
                InstructionModel i = new(instruction);
                dial.Spin(i.TurnDistance);
            }

            Assert.Equal(target, dial.ZeroClicks);
        }
    }
}
