
using System;
//factorial
class Test
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Enter a number to calculate its factorial:");
        int number = Convert.ToInt32(Console.ReadLine());
        int factorial = 1;

        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"The factorial of {number} is: {factorial}");
    }
}   