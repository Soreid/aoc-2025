using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDaySeven;

namespace AdventOfCodeTests
{
    public class DaySevenTests
    {
        public string[] puzzleStart = new string[] {
            ".....S.....",
            "...........",
            ".....^.....",
            "...........",
            "....^......",
            "...........",
            "...^.^.....",
            "...........",
            "..^.^.^....",
            "...........",
            "...^...^...",
            "...........",
            ".^...^..^..",
            "..........."
        };

        public string[] puzzleEnd = new string[] {
            ".....S.....",
            ".....|.....",
            "....|^|....",
            "....|.|....",
            "...|^||....",
            "...|.||....",
            "..|^|^|....",
            "..|.|.|....",
            ".|^|^|^|...",
            ".|.|.|.|...",
            ".||^|||^|..",
            ".||.|||.|..",
            "|^|.|^||^|.",
            "|.|.|.||.|."
        };

        [Fact]
        public void CountSplits()
        {
            DaySeven daySeven = new(puzzleStart);
            Assert.Equal(12, daySeven.Splits);
        }

        [Fact]
        public void DiagramIsAccurate()
        {
            DaySeven daySeven = new(puzzleStart);
            Assert.Equal(puzzleEnd, daySeven.Outputs);
        }

        [Fact]
        public void CorrectPossiblePaths()
        {
            DaySeven daySeven = new(puzzleStart);
            Assert.Equal(22, daySeven.PossibleSplits);
        }
    }
}
