//method

using System;

class Test
{

    //static: we can call this method without creating an instance of the class-->Add()
    public static void Add(int number1,int number2)
    {
        int sum = number1 + number2;
        Console.WriteLine("Sum: " + sum);
    }

    //without static: we need to create an instance of the class to call the method .--> obj.Multiply()
    public void Multiply(int number1, int number2)
    {
        int product = number1 * number2;
        Console.WriteLine("Product: " + product);
    }

    public static void Greeting()
    {
        Console.WriteLine("hello");
    }

    public static void Message(string msg)
    {
        Console.WriteLine(msg);
    }
    
    // method with return
    public static int Square(int number)
    {
        return number*number;
    }
    
    public static void Main(string[] args)
    {
        // 1. Calling static methods (No instance needed)
        Greeting();

        Add(10,20);

        Message("Hello from Message");

        int s=Square(5);
        Console.WriteLine($"Square of 5 is {s}");

        // 2. Calling non-static method (Requires an instance/object of the class)
        Test obj = new Test();
        obj.Multiply(10, 5);
    }
}