# ConsoleUtility

## ConsoleUtility.ProgressBar

<pre>[■■■■■■■■  ] 80.00% Complete.</pre>

&darr; &darr; &darr;

<pre>
[■■■■■■■■■■] 100.00% Complete.
Process completed.
</pre>

---


### Project Description

This project aims to provide easy, reusable implementation for a progress bar to be displayed in a console application to reassure users that longer tasks are progressing towards completion.
Its primary design is for monitoring automated tasks that are not run on a CI or CD machine but rather in the background on a user's device.


### Project Specifications

This project builds a dynamic link library (DLL) written in C# targeting .NET Framework 4.7.2.
Since this project has been built using C#, it is NOT a Windows DLL - it can only be referenced and called from other .NET languages as an assembly. 


### Project Files

The ConsoleUtility solution contains two C# files for this specific class library - ProgressBar.cs and ProgressBarTests.cs. They are used for building the DLL and performing tests, respectively.
To generate the ProgressBar DLL on your own, build the solution in Visual Studio. Alternatively, download and use the DLL from [here](ProgressBar/bin/Debug/).

---


### ProgressBar Class

#### Constructors

`ProgressBar()` initializes a new instance of the ProgressBar Class with the default properties.

`ProgressBar(int, int)` initializes a new instance of the ProgressBar Class with the given total number of steps and bar size.

`ProgressBar(char, char, char, int, int)` initializes a new instance of the ProgressBar Class with the given filler, left and right brackets, total number of steps, and  bar size.


#### Properties

`Filler` Gets or sets the character to fill the bar with.

`LBracket` Gets or sets the character to use as the left bracket of the bar.

`RBracket` Gets or sets the character to use as the right bracket of the bar.

`BarSize` Gets or sets the bar size, not including the brackets and percent complete tag.

`NumSteps` Gets or sets the total number of steps to fill the bar.

`Bar` Gets or sets the current bar to display using the other properties.


#### Methods

`DrawCurrent()` Draws the current status of the bar in the Console.

`DrawEmpty()` Draws an empty bar with the 0% tag.

`DrawFilled()` Draws a filled bar with the 100% tag.

`DrawUpdate()` Increments numSteps, rebuilds the bar if needed, and draws it with the correct tag.

---


### Remarks

Since this class is designed to be used in automated console applications, the most common constructor to use would be ProgressBar(int, int).

The standard use of this class would be to create an instance of a bar outside of a `for` loop, display the empty bar using `DrawEmpty()` before entering the loop, and then call `DrawUpdate()` within each iteration of the loop.

For cases where you may end up with 0 steps to complete (condition of the `for` loop is never satisfied) but still want to display the bar, create an instance of the bar and display it and the 0% and tag using `DrawEmpty()` before entering an `if/else` statement. Call `DrawUpdate()` from inside your `for` loop in one of the branches of the `if/else` while calling `DrawFilled()` from the other.
An example of this is demonstrated below.

---


### Code Example

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
        var numSteps = 0;
        var barSize = 82;
        
        var myBar = new ProgressBar(filler, lBracket, rBracket, numSteps, barSize);
        myBar.DrawEmpty();
        
        // If there are some steps to complete, we can enter the for loop and update the bar.
        if (numSteps > 0)
        {
            for (int i = 0; i < numSteps; i++)
            {
                myBar.DrawUpdate();
                Thread.Sleep(25);
            }
        }
        
        // If there are no steps to complete, we can show the filled bar and 100% tag.
        else
        {
            myBar.DrawFilled();
        }
        
        Console.Read();
    }
}
```

#### Output
<pre>{                                                                                  } 0.00% Complete.</pre>
&darr; &darr; &darr;

<pre>{|||||||||||||||||||||||||||||||||||||||                                           } 47.76% Complete.</pre>
&darr; &darr; &darr;

<pre>
{||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||} 100.00% Complete.
Process Completed.
</pre>
