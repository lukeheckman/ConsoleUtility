using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleUtility;
using System.Threading;

namespace ProgressBarUnitTests
{
    [TestClass]
    public class ProgressBarUnitTests
    {
        [TestMethod]
        public void Constr_No_Params()
        {
            var numSteps = 101;
            var barSize = 20;
            var myBar = new ProgressBar(numSteps, barSize);

            myBar.DrawCurrent();

            for (int i = 0; i < numSteps; i++)
            {
                myBar.DrawUpdate();

                Thread.Sleep(25);
            }
        }
    }
}
