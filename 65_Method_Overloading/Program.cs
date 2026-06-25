// 65. Method Overloading (Compile-Time Polymorphism)
/*
    Polymorphism means "many forms". 
    Method Overloading is when multiple methods have the SAME name, but DIFFERENT parameters.
*/
using System;

public class Calculator
{
    // Method 1: Adds two integers
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method 2: Adds THREE integers (Same name, different number of parameters)
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    // Method 3: Adds two doubles (Same name, different type of parameters)
    public double Add(double a, double b)
    {
        return a + b;
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Calculator calc = new Calculator();

        // The compiler automatically figures out which method to call based on what we pass!
        Console.WriteLine($"Adding two integers (5, 10): {calc.Add(5, 10)}");
        Console.WriteLine($"Adding three integers (5, 10, 15): {calc.Add(5, 10, 15)}");
        Console.WriteLine($"Adding two doubles (5.5, 10.5): {calc.Add(5.5, 10.5)}");
    }
}
