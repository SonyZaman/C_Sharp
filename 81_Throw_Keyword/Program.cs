// 81. Throw Keyword
/*
    The 'throw' keyword allows you to create a custom error. 
    It is used together with an exception class to throw a newly created exception.
*/
using System;

class Test
{
    public static void CheckAge(int age)
    {
        if (age < 18)
        {
            // We intentionally crash/stop the process if the condition fails
            throw new Exception("Access denied - You must be at least 18 years old.");
        }
        else
        {
            Console.WriteLine("Access granted - You are old enough!");
        }
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            
            CheckAge(age);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error caught: {ex.Message}");
        }
    }
}
