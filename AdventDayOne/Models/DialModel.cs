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
        public int ZeroClicks { get; private set; } = 0;

        public void Spin(int distance)
        {
            int start = CurrentNumber;
            distance = FullSpins(distance);

            CurrentNumber += distance;

            if (CurrentNumber == MaxNumber)
            {
                CurrentNumber -= MaxNumber;
            }
            if (CurrentNumber == -MaxNumber)
            {
                CurrentNumber += MaxNumber;
            }

            if (CurrentNumber > MaxNumber)
            {
                CurrentNumber -= MaxNumber;
                ZeroClicks++;
            }
            if (CurrentNumber < 0 && start != 0)
            {
                CurrentNumber += MaxNumber;
                ZeroClicks++;
            }

            if (CurrentNumber == 0)
            {
                ZeroClicks++;
            }
        }

        int FullSpins(int distance)
        {
            while(distance >= MaxNumber)
            {
                distance -= MaxNumber;
                ZeroClicks++;
            }

            while(distance <= -MaxNumber)
            {
                distance += MaxNumber;
                ZeroClicks++;
            }

            return distance;
        }
    }
}
