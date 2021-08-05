using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgressBar
{
    public class ProgressBar
    {
        private const char blank = ' ';
        private const string del = "\b";
        private int numCompleted = 0;

        public ProgressBar() {
            Bar = GetBar(numCompleted);
        }


        public ProgressBar(int numSteps, int barSize)
        {
            NumSteps = numSteps;
            BarSize = barSize;
            Bar = GetBar(numCompleted);
        }


        public ProgressBar(char statusChar, char lBracketChar, char rBracketChar, int numSteps, int barSize)
        {
            // Properties init performed by automatically calling the set method defined below
            /*
             * Acts the same as if private attributes were declared before the constructor and initialized like
             * this.status = statusChar;
             * this.lBracket = lBracketChar;
             * this.rBracket = rBracketChar;
             * size = 20;
             */

            Status = statusChar;
            LBracket = lBracketChar;
            RBracket = rBracketChar;
            NumSteps = numSteps;
            BarSize = barSize;
            Bar = GetBar(numCompleted);
        }


        public char Status { get; set; } = '■';


        public char LBracket { get; set; } = '[';


        public char RBracket { get; set; } = ']';


        public int BarSize { get; set; } = 10;


        public int NumSteps { get; set; } = 100;


        private string Bar { get; set; }


        private string GetBar(int numCompleted)
        {
            var bar = new List<char>();

            bar.Add(LBracket);

            for (int i = 0; i < numCompleted; i++)
            {
                bar.Add(Status);
            }

            for (int i = 0; i < BarSize - numCompleted; i++)
            {
                bar.Add(blank);
            }

            bar.Add(RBracket);

            return String.Join("", bar.ToArray());
        }


        private void Update()
        {
            numCompleted++;

            float oldRatio = numCompleted - 1 / NumSteps;
            float newRatio = numCompleted / NumSteps;

            int oldUnits = (int)oldRatio * BarSize;
            int newUnits = (int)newRatio * BarSize;

            if (newUnits > oldUnits)
            {
                Bar = GetBar(newUnits);
            }
        }


        private void ClearLine()
        {
            var delLine = "";
            for (int i = 0; i < BarSize + 2; i++)
            {
                delLine = String.Concat(delLine, del);
            }

            Console.Write(delLine);
        }


        public void Draw()
        {
            Update();
            ClearLine();
            Console.WriteLine(Bar);
        }


        //public override string ToString()
        //{
        //    return this.bar;
        //}

    }
}
