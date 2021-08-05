using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProgressBar
{
    class Program
    {


        static void Main(string[] args)
        {
            var myBar = new ProgressBar(10, 10);
            myBar.DrawCurrent();
            for (int i = 0; i < 10; i++)
            {
                myBar.DrawUpdate();
                Thread.Sleep(200);
            }
            Console.Read();
        }
    }
}
