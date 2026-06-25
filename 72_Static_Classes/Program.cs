// 72. Static Classes & Members
/*
    A 'static' class cannot be instantiated using 'new'. 
    All its members must also be static. 
    It is useful for creating utility/helper classes (like C#'s built-in 'Math' class).
*/
using System;

// We use the 'static' keyword on the class
public static class MathHelper
{
    // The members must also be static
    public static double Pi = 3.14159;

    public static int Add(int a, int b)
    {
        return a + b;
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // MathHelper helper = new MathHelper(); // ERROR! Cannot create an instance of a static class

        // We access static members directly using the Class Name!
        Console.WriteLine($"The value of Pi is: {MathHelper.Pi}");
        
        int sum = MathHelper.Add(10, 25);
        Console.WriteLine($"10 + 25 = {sum}");
    }
}
