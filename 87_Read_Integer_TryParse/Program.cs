// 87. Method for Reading Integer Input using TryParse
/*
    This does the exact same thing as project 71, but using int.TryParse.
    
    Q: Why use int.TryParse instead of try-catch here?
    A: 1. Performance: Throwing exceptions is very slow and expensive for the CPU. 
       2. Design: Exceptions should be for "unexpected" errors. A user typing invalid 
          input is completely expected. TryParse handles this normal validation perfectly!
*/
using System;

class Test
{
    // Reusable method for robust input using TryParse
    public static int ReadIntegerInput(string prompt)
    {
        while (true) // Keep looping infinitely until a valid number is provided
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            // Try to parse the input into an integer safely without exceptions
            if (int.TryParse(input, out int result))
            {
                // If parsing was successful, return the valid number
                return result; 
            }
            else
            {
                // If it failed (e.g. they typed words or pressed Enter blankly)
                Console.WriteLine("Invalid input! Please enter a valid number.\n");
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the TryParse Input Demo!");
        
        int age = ReadIntegerInput("Please enter your age: ");
        int favNumber = ReadIntegerInput("Please enter your favorite number: ");
        
        Console.WriteLine("\n--- Data Collected ---");
        Console.WriteLine($"Your age is: {age}");
        Console.WriteLine($"Your favorite number is: {favNumber}");
    }
}
