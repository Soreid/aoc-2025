using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayOne.Models
{
    internal class InstructionModel
    {
        public int TurnDistance { get; private set; }

        public InstructionModel(string instruction)
        {
            if(!int.TryParse(instruction.AsSpan(1), out int distance))
            {
                throw new Exception($"Numeric section of instruction not found in {instruction}");
            }
            int direction;
            if (instruction[0] == 'R')
            {
                direction = 1;
            }
            else if (instruction[0] == 'L')
            {
                direction = -1;
            }
            else
            {
                throw new Exception($"Unrecognized instruction direction: {instruction}");
            }
            TurnDistance = distance * direction;
        }
    }
}
