// 77. Exception Handling Introduction
/*
    An Exception is a problem that arises during the execution of a program.
    When an error occurs, C# generates an exception and stops the normal flow 
    of the program. This crashes the application if the exception is not handled.
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Program has started.");
        
        Console.Write("Enter a number: ");
        // If the user enters a word (like "hello"), this line will throw a FormatException
        // and the program will crash immediately. The next line will never execute.
        int number = Convert.ToInt32(Console.ReadLine()); 
        
        Console.WriteLine($"You entered: {number}");
        Console.WriteLine("Program has ended successfully.");
    }
}
