using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDayOne.Models
{
    internal class DialModel(int currentNumber, int maxNumber)
    {
        public int CurrentNumber { get; private set; } = currentNumber;
        public int MaxNumber { get; private set; } = maxNumber;

        public void Spin(int distance)
        {
            CurrentNumber += distance;
            CurrentNumber = CurrentNumber % MaxNumber;
        }
    }
}
