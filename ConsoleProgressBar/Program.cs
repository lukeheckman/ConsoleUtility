using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgressBar
{
    class Program
    {


        static void Main(string[] args)
        {
            var myBar = new ProgressBar(1, 10);
            for (int i = 0; i < 10; i++)
            {
                myBar.Draw();
                Console.Read();
            }
            Console.Read();
        }
    }
}
