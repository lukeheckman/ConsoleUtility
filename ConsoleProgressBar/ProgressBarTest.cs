using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProgressBar
{
    class ProgressBarTest
    {
        static void Main(string[] args)
        {
            //var numSteps = 101;
            //var barSize = 20;
            //var myBar = new ProgressBar(numSteps, barSize);
            //myBar.DrawCurrent();


            var statusChar = '~';
            var lBracketChar = '{';
            var rBracketChar = '+';
            var numSteps = 69;
            var barSize = 82;
            var myBar = new ProgressBar(statusChar, lBracketChar, rBracketChar, numSteps, barSize);

            for (int i = 0; i < numSteps; i++)
            {
                myBar.DrawUpdate();
                Thread.Sleep(25);
            }

            Console.Read();
        }
    }
}
