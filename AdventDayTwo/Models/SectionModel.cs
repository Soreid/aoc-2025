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
        public long Start { get; private set; } = Int64.Parse(range.Split('-')[0]);
        public long End { get; private set; } = Int64.Parse(range.Split('-')[1]);

        public IEnumerable<string> GetValues()
        {
            for (long i = Start; i <= End; i++)
            {
                yield return i.ToString();
            }
        }
    }
}
