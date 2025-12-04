using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace AdventDayTwo.Models
{
    internal class SectionModel(string range)
    {
        public int Start { get; private set; } = int.Parse(range.Split('-')[0]);
        public int End { get; private set; } = int.Parse(range.Split('-')[1]);

        public IEnumerable<int> GetValues()
        {
            for (int i = Start; i <= End; i++)
            {
                yield return i;
            }
        }
    }
}
