// 078. Try Catch
/*
    To prevent the program from crashing, we use a try-catch block.
    - 'try': Contains the code that might throw an exception.
    - 'catch': Contains the code that handles the exception if one occurs.
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Program has started.");
        
        try
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You entered: {number}");
        }
        catch (Exception ex)
        {
            // If an error happens in the 'try' block, it immediately jumps here
            Console.WriteLine("An error occurred! You didn't enter a valid number.");
            // You can also print the system's exact error message:
            // Console.WriteLine(ex.Message);
        }
        
        // Because we caught the exception, the program DOES NOT crash!
        Console.WriteLine("Program has ended successfully.");
    }
}
