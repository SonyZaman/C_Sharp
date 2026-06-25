// 091. ArgumentOutOfRangeException
/*
    ArgumentOutOfRangeException is the 3rd common argument-related exception.
    It is used specifically when a provided value does not fall within the expected or allowed range.
*/
using System;

class Test
{
    public static void SetAge(int age)
    {
        // Age must be between 0 and 120
        if (age < 0 || age > 120)
        {
            // The constructor takes the parameter name, the actual value, and the custom message
            throw new ArgumentOutOfRangeException(nameof(age), age, "Age must be between 0 and 120.");
        }
        
        Console.WriteLine($"Age {age} set successfully!");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Testing Valid Age ---");
        try
        {
            SetAge(25);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n--- Testing Invalid Age (-5) ---");
        try
        {
            SetAge(-5);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Error: Out of range value provided!");
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"Parameter Name: {ex.ParamName}");
            Console.WriteLine($"Actual Value Provided: {ex.ActualValue}");
        }
    }
}
