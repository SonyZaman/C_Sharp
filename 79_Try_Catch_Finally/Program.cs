// 79. Try Catch Finally
/*
    The 'finally' block is used to execute a given set of statements, 
    whether an exception is thrown or not thrown.
    It is typically used to close files or release resources.
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Your age is: {age}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: Please enter numbers only.");
        }
        finally
        {
            // This block will ALWAYS execute, no matter what happened above.
            Console.WriteLine("The 'finally' block always executes. Cleanup operations go here.");
        }
        
        Console.WriteLine("Program continues...");
    }
}
