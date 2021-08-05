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
        private int cursorLeft = Console.CursorLeft;
        private int cursorTop = Console.CursorTop;

        public ProgressBar() {
            Bar = GetUpdate();
        }


        public ProgressBar(int numSteps, int barSize)
        {
            NumSteps = numSteps;
            BarSize = barSize;
            Bar = GetUpdate();
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
            Bar = GetUpdate();
        }


        public char Status { get; set; } = '■';


        public char LBracket { get; set; } = '[';


        public char RBracket { get; set; } = ']';


        public int BarSize { get; set; } = 10;


        public int NumSteps { get; set; } = 100;


        private string Bar { get; set; }


        // Increases numCompleted by 1 and checks to see if the bar needs a visual update.
        private Boolean NeedsUpdate()
        {
            numCompleted++;

            double oldRatio = (double)(numCompleted - 1) / NumSteps;
            double newRatio = (double) numCompleted / NumSteps;

            int oldUnits = (int)(Math.Round(oldRatio * BarSize, MidpointRounding.AwayFromZero));
            int newUnits = (int)(Math.Round(newRatio * BarSize, MidpointRounding.AwayFromZero));

            if (newUnits > oldUnits)
            {
                return true;
            }

            return false;
        }


        // Updates and returns the new bar as a string.
        private string GetUpdate()
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

            return String.Concat((String.Join("", bar.ToArray())), GetPercentComplete());
        }


        private string GetPercentComplete()
        {
            double ratio = (double) numCompleted / NumSteps;
            double percent = ratio * 100;
            return String.Concat(percent.ToString(), "% Complete.");
        }


        public void DrawCurrent()
        {
            Console.WriteLine(Bar);
        }


        public void DrawUpdate()
        {
            if (NeedsUpdate())
            {
                Bar = GetUpdate();
            }

            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.WriteLine(Bar);
        }
    }
}
