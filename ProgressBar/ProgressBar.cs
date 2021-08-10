﻿using System;
using System.Collections.Generic;

namespace ProgressBar
{
    public class ProgressBar
    {
        private const char blank = ' ';
        private int numCompleted = 0;
        private int progress = 0;
        private int cursorLeft = Console.CursorLeft;
        private int cursorTop = Console.CursorTop;

        public ProgressBar()
        {
            Rebuild();
            SetCursorVisibility();
        }

        public ProgressBar(int numSteps)
        {
            NumSteps = numSteps;
            Rebuild();
            SetCursorVisibility();
        }


        public ProgressBar(int numSteps, int barSize)
        {
            NumSteps = numSteps;
            BarSize = barSize;
            Rebuild();
            SetCursorVisibility();
        }


        public ProgressBar(char fillerChar, char lBracketChar, char rBracketChar, int numSteps, int barSize)
        {
            // Properties init performed by automatically calling the set method defined below
            /*
             * Acts the same as if private attributes were declared before the constructor and initialized like
             * this.filler = fillerChar;
             * this.lBracket = lBracketChar;
             * this.rBracket = rBracketChar;
             * size = 20;
             */

            Filler = fillerChar;
            LBracket = lBracketChar;
            RBracket = rBracketChar;
            NumSteps = numSteps;
            BarSize = barSize;
            Rebuild();
            SetCursorVisibility();
        }


        public char Filler { get; set; } = '■';

        public char LBracket { get; set; } = '[';

        public char RBracket { get; set; } = ']';

        public int BarSize { get; set; } = 10;

        public int NumSteps { get; set; } = 100;

        private string Bar { get; set; }


        private void SetCursorVisibility()
        {
            Console.CursorVisible = false;
        }


        // Increases numCompleted by 1 and checks to see if the bar needs a visual update.
        private Boolean NeedsRebuilt()
        {
            numCompleted++;

            double oldRatio = (double)(numCompleted - 1) / NumSteps;
            double newRatio = (double)numCompleted / NumSteps;

            int oldUnits = (int)Math.Floor(oldRatio * BarSize);
            int newUnits = (int)Math.Floor(newRatio * BarSize);

            if (newUnits > oldUnits)
            {
                progress = newUnits;
                return true;
            }

            return false;
        }


        // Updates and returns the new bar as a string.
        private void Rebuild()
        {
            var bar = new List<char>();

            bar.Add(LBracket);

            for (int i = 0; i < progress; i++)
            {
                bar.Add(Filler);
            }

            for (int i = 0; i < BarSize - progress; i++)
            {
                bar.Add(blank);
            }

            bar.Add(RBracket);

            Bar = String.Join("", bar.ToArray());
        }


        private string GetPercent()
        {
            double ratio = (double)numCompleted / NumSteps;
            double percent = ratio * 100;

            if (percent >= 100)
            {
                return String.Concat(" 100.00% Complete.\nProcess completed.\n");
            }

            // Format is first arg (indexed at 0) is formatted as x.00
            return String.Concat(" ", String.Format("{0:0.00}", percent), "% Complete.");
        }


        public void DrawCurrent()
        {
            Console.WriteLine(Bar);
        }


        public void Update()
        {
            if (NeedsRebuilt())
            {
                Rebuild();
            }

            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write(Bar);
            Console.Write(GetPercent());
        }
    }
}