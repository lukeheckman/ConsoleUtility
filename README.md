# ConsoleProgressBar

<pre>[■■■■■■■■  ] 80.00% Complete.</pre>

&darr; &darr; &darr;

<pre>
[■■■■■■■■■■] 100.00% Complete.
Process completed.
</pre>

---


## Project Description

This project aims to provide easy, reusable implementation for a progress bar to be displayed in a console application to reassure users that longer tasks are progressing towards completion.
Its primary design is for monitoring automated tasks that are not run on a CI or CD machine but rather in the background on a user's device.


## Project Specifications

This project builds a dynamic link library (DLL) written in C# targeting .NET Framework 4.7.2.
Since this project has been built using C#, it is NOT a Windows DLL - it can only be referenced and called from other .NET languages as an assembly. 


## Project Files

The ConsoleProgressBar solution contains a C# file (ProgressBar.cs) used for building the class.
To generate the ConsoleProgressBar DLL on your own, build the solution in Visual Studio. Alternatively, download and use the DLL from [here](ProgressBar/bin/Debug/).

---


## ProgressBar Class

### Constructors

`ProgressBar()` initializes a new instance of the ProgressBar Class with the default properties.

`ProgressBar(int, int)` initializes a new instance of the ProgressBar Class with the given total number of steps and bar size.

`ProgressBar(char, char, char, int, int)` initializes a new instance of the ProgressBar Class with the given filler, left and right brackets, total number of steps, and  bar size.


### Properties

`Filler` Gets or sets the character to fill the bar with.

`LBracket` Gets or sets the character to use as the left bracket of the bar.

`RBracket` Gets or sets the character to use as the right bracket of the bar.

`BarSize` Gets or sets the bar size, not including the brackets and percent complete tag.

`NumSteps` Gets or sets the total number of steps to fill the bar.

`Bar` Gets or sets the current bar to display using the other properties.


### Methods

`NeedsUpdate()` Increases the number of completed steps by 1 and returns a Boolean value of whether the bar needs to be updated or not based on the number completed out of the total number of steps.

`GetUpdate()` Rebuilds the bar and returns the updated bar as a string.

`GetPercentComplete()` Formats the percent of steps complete out of the total and returns it as a string to display next to the bar.

`DrawCurrent()` Draws the current status of the bar in the Console.

`DrawUpdate()` Checks to see if the bar needs updated, builds and sets the new bar (if needed), and writes the bar and the percent completed to the Console.

---


## Remarks

Since this class is designed to be used in automated console applications, the most common constructor to use would be ProgressBar(int, int).
The standard use of this class would be to create an instance outside of a for loop, display the empty bar using the DrawCurrent method before entering the loop, and then call the DrawUpdate method within each iteration of the loop.

---


## Code Example

```c#
using System;
using System.Threading;
using ConsoleUtility;

class Test
{
    static void Main(string[] args)
    {
        var filler = '|';
        var lBracket = '{';
        var rBracket = '}';
        var numSteps = 67;
        var barSize = 82;

        // Create a ProgressBar and define custom filler and bracket chars along with the number of steps and bar size.
        var myBar = new ProgressBar(filler, lBracket, rBracket, numSteps, barSize);

        // Draw the empty bar.
        myBar.DrawCurrent();

        for (int i = 0; i < numSteps; i++)
        {
            // Draw the updated bar (if needed) and recalculate the percentage of tasks done.
            myBar.Update();

            Thread.Sleep(25);
        }
    }
}
```

### Output
<pre>{                                                                                  } 0.00% Complete.</pre>
&darr; &darr; &darr;

<pre>{|||||||||||||||||||||||||||||||||||||||                                           } 47.76% Complete.</pre>
&darr; &darr; &darr;

<pre>
{||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||} 100.00% Complete.
Process Completed.
</pre>
