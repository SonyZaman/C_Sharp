// 085. Argument Null Exception
/*
    ArgumentNullException is a specific type of ArgumentException. 
    It is thrown when a null reference is passed to a method that does not accept it as a valid argument.
*/
using System;

class Test
{
    public static void PrintMessage(string message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "The message cannot be null.");
        }
        
        Console.WriteLine($"Message: {message}");
    }

    public static void Main(string[] args)
    {
        try
        {
            string? myNullString = null;
            
            // This will trigger the ArgumentNullException
            PrintMessage(myNullString!); // The '!' tells the compiler to ignore the null warning here so we can test it
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Null Argument Error Caught!");
            Console.WriteLine($"Message: {ex.Message}");
        }
    }
}
