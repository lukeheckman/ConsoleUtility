using System;
using System.Threading;

namespace ConsoleUtility
{
    class Test
    {
        static void Main(string[] args)
        {
            //var numSteps = 101;
            //var barSize = 20;
            //var myBar = new ProgressBar(numSteps, barSize);


            var filler = '|';
            var lBracket = '{';
            var rBracket = '}';
            var numSteps = 67;
            var barSize = 82;
            var myBar = new ProgressBar(filler, lBracket, rBracket, numSteps, barSize);


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
