using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDaySeven
{
    public class DaySeven
    {
        public string[] Outputs { get; private set; }
        public int Splits { get; private set; }

        public DaySeven(string[] inputs)
        {
            Outputs = Fire(inputs);
        }

        internal string[] Fire(string[] inputs)
        {
            string[] outputs = new string[inputs.Length];
            List<int> beams = new List<int>();
            outputs[0] = inputs[0];
            beams.Add(inputs[0].IndexOf('S'));

            for (int i = 1; i < inputs.Length; i++)
            {
                string line = "";
                for(int j = 0; j < inputs[i].Length; j++)
                {
                    if (!beams.Contains(j))
                    {
                        line += inputs[i][j];
                    }
                    else if(beams.Contains(j) && inputs[i][j] == '.')
                    {
                        line += '|';
                    }
                    else if (beams.Contains(j) && inputs[i][j] == '^')
                    {
                        beams.RemoveAll(x => x == j - 1 || x == j || x == j + 1);
                        beams.Add(j - 1);
                        beams.Add(j + 1);
                        line = line.Remove(line.Length - 1);
                        line += "|^";
                        Splits++;
                    }
                }

                outputs[i] = line;
            }

            return outputs;
        }
    }
}
