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
        private int Password = 0;

        public DayOne(string[] instructions, int dial_start, int dial_length)
        {
            Instructions = new InstructionModel[instructions.Length];

            for(int i = 0; i < instructions.Length; i++)
            {
                Instructions[i] = new InstructionModel(instructions[i]);
            }

            Dial = new DialModel(dial_start, dial_length);
        }

        private void SpinDial(InstructionModel instruction)
        {
            Dial.Spin(instruction.TurnDistance);
            if(Dial.CurrentNumber == 0)
            {
                Password++;
            }
        }

        public int FindPassword()
        {
            foreach(InstructionModel instruction in Instructions)
            {
                SpinDial(instruction);
            }
            return Password;
        }
    }
}
