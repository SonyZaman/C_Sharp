// 080. Multiple Catch Blocks
/*
    A 'try' block can be followed by multiple 'catch' blocks.
    This allows you to handle different types of exceptions in different ways.
    Always put the most specific exceptions first, and the general 'Exception' last.
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter a number to divide 100 by: ");
            int divisor = Convert.ToInt32(Console.ReadLine());
            
            int result = 100 / divisor;
            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            // Specifically handles when the user types letters instead of numbers
            Console.WriteLine("Format Error: You must enter a valid number, not text.");
        }
        catch (DivideByZeroException)
        {
            // Specifically handles division by zero
            Console.WriteLine("Math Error: You cannot divide a number by zero!");
        }
        catch (Exception ex)
        {
            // A general fallback for any other unexpected errors
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
