// 084. Argument Exception
/*
    ArgumentException is thrown when a method is invoked and at least one of the 
    passed arguments does not meet the parameter specification of the invoked method.
*/
using System;

class Test
{
    public static void SetPassword(string password)
    {
        // Password must be at least 6 characters long
        if (password.Length < 6)
        {
            // We pass the error message and the name of the parameter that caused the error
            throw new ArgumentException("Password is too short. It must be at least 6 characters.", nameof(password));
        }
        
        Console.WriteLine("Password set successfully!");
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter a new password (min 6 chars): ");
            string? pwd = Console.ReadLine();
            
            SetPassword(pwd ?? "");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid Argument: {ex.Message}");
            Console.WriteLine($"Parameter Name that failed: {ex.ParamName}");
        }
    }
}
