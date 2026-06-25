// 66. Operator Overloading
/*
    Operator overloading allows you to redefine how C# operators (like +, -, *, /) 
    work with your own custom objects.
*/
using System;

public class Box
{
    public int Length;
    public int Width;

    public Box(int length, int width)
    {
        Length = length;
        Width = width;
    }

    // We overload the '+' operator! 
    // It must be 'public static' and return the class type.
    public static Box operator +(Box b1, Box b2)
    {
        // When two boxes are added, we add their lengths and widths together!
        return new Box(b1.Length + b2.Length, b1.Width + b2.Width);
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Box box1 = new Box(10, 5);
        Box box2 = new Box(20, 15);

        // We can now use the '+' symbol directly on our objects!
        Box box3 = box1 + box2;

        Console.WriteLine($"Combined Box Length: {box3.Length}"); // 10 + 20 = 30
        Console.WriteLine($"Combined Box Width: {box3.Width}");   // 5 + 15 = 20
    }
}
