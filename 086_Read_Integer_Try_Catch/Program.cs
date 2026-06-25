// 086. Method for Reading Integer Input using Try-Catch
/*
    This creates a robust method that forces the user to enter a valid integer.
    It uses a try-catch block to catch formatting errors if the user enters text.
*/
using System;

class Test
{
    // Reusable method for robust input using Exception Handling
    public static int ReadIntegerInput(string prompt)
    {
        while (true) // Keep looping infinitely until a valid number is provided
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            try
            {
                // This line will throw a FormatException if 'input' is not a valid number
                int result = Convert.ToInt32(input);
                
                // If the conversion succeeds, we immediately return the valid number
                // 'return' also breaks out of the while loop!
                return result; 
            }
            catch (FormatException)
            {
                // We catch the error so the program doesn't crash, and the loop repeats
                Console.WriteLine("Invalid input! Please enter a valid number.\n");
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Try-Catch Input Demo!");
        
        // Use our robust method to get the user's age
        int age = ReadIntegerInput("Please enter your age: ");
        
        // Use our robust method to get the user's favorite number
        int favNumber = ReadIntegerInput("Please enter your favorite number: ");
        
        Console.WriteLine("\n--- Data Collected ---");
        Console.WriteLine($"Your age is: {age}");
        Console.WriteLine($"Your favorite number is: {favNumber}");
    }
}
