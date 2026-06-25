// 083. Divide By Zero Exception
/*
    DivideByZeroException is thrown when there is an attempt to divide an integer 
    or decimal value by zero.
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        int number1 = 100;
        int number2 = 0;

        try
        {
            // This will trigger a DivideByZeroException
            int result = number1 / number2; 
            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Mathematical Error Occurred!");
            Console.WriteLine($"Message: {ex.Message}");
        }
    }
}
