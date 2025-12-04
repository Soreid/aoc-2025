using AdventDayOne.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayOne
{
    public class DayOne
    {
        private DialModel Dial;
        private InstructionModel[] Instructions;

        public DayOne(string[] instructions, int dial_start, int dial_length)
        {
            Instructions = new InstructionModel[instructions.Length];

            for(int i = 0; i < instructions.Length; i++)
            {
                Instructions[i] = new InstructionModel(instructions[i]);
            }

            Dial = new DialModel(dial_start, dial_length);
        }

        public int FindPassword()
        {
            foreach(InstructionModel instruction in Instructions)
            {
                Dial.Spin(instruction.TurnDistance);
            }
            return Dial.ZeroClicks;
        }
    }
}
