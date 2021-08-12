using System;
using System.Threading;
using ConsoleUtility;

namespace ConsoleUtilityTests
{
    class ProgressBarTests
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


            myBar.DrawInitial();

            for (int i = 0; i < numSteps; i++)
            {
                myBar.DrawUpdate();

                Thread.Sleep(25);
            }

            Console.Read();
        }

    }

    //    static void Main(string[] args)
    //    {
    //        var filler = '|';
    //        var lBracket = '{';
    //        var rBracket = '}';
    //        var numSteps = 0;
    //        var barSize = 82;
    //        var myBar = new ProgressBar(filler, lBracket, rBracket, numSteps, barSize);


    //        myBar.DrawInitial();

    //        if (numSteps > 0)
    //        {
    //            for (int i = 0; i < numSteps; i++)
    //            {
    //                myBar.DrawUpdate();

    //                Thread.Sleep(25);
    //            }
    //        }
    //        else
    //        {
    //            myBar.DrawFinal();
    //        }

    //        Console.Read();
    //    }
    //}
}