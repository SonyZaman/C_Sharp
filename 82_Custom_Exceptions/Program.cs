// 82. Custom Exceptions (User-Defined Exceptions)
/*
    Sometimes the built-in exceptions (like ArgumentException) are not specific enough for your application's domain.
    You can create your own custom exceptions by inheriting from the base 'Exception' class.
*/
using System;

// 1. Create a class that inherits from Exception
// It is a convention to end the class name with the word "Exception"
public class InvalidAgeException : Exception
{
    // 2. Create constructors that pass messages to the base Exception class
    public InvalidAgeException() : base("The provided age is invalid.") 
    { 
    }

    public InvalidAgeException(string message) : base(message) 
    { 
    }
}

class Test
{
    public static void RegisterVoter(int age)
    {
        if (age < 18)
        {
            // 3. Throw your custom exception
            throw new InvalidAgeException("Voter must be at least 18 years old to register.");
        }
        
        Console.WriteLine("Voter registered successfully!");
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter your age to register to vote: ");
            int age = Convert.ToInt32(Console.ReadLine());
            
            RegisterVoter(age);
        }
        catch (InvalidAgeException ex) // 4. Catch your custom exception specifically
        {
            Console.WriteLine($"\n--- Custom Exception Caught ---");
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n--- General Error ---");
            Console.WriteLine(ex.Message);
        }
    }
}
