using System;
using System.Threading;

namespace ConsoleProgressBar
{
    class ProgressBarTest
    {
        static void Main(string[] args)
        {
            //var numSteps = 101;
            //var barSize = 20;
            //var myBar = new ProgressBar(numSteps, barSize);


            var statusChar = '|';
            var lBracketChar = '{';
            var rBracketChar = '}';
            var numSteps = 69;
            var barSize = 82;
            var myBar = new ProgressBar(statusChar, lBracketChar, rBracketChar, numSteps, barSize);


            myBar.DrawCurrent();
            for (int i = 0; i < numSteps; i++)
            {
                myBar.Update();
                Thread.Sleep(25);
            }

            Console.Read();
        }
    }
}
