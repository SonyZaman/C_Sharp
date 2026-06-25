// 101. Generics Introduction (<T>)
/*
    Generics allow you to write a class or method that works with ANY data type.
    Instead of writing three different methods to print an int array, string array, and double array,
    you write ONE method using a "Type Parameter" usually named <T>.
*/
using System;

// 1. Generic Class
public class Box<T>
{
    public T Content { get; set; }

    public Box(T content)
    {
        Content = content;
    }
}

class Test
{
    // 2. Generic Method
    // This method accepts an array of ANY type (T) and prints it!
    public static void PrintArray<T>(T[] array)
    {
        foreach (T item in array)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Generic Methods ---");
        int[] numbers = { 1, 2, 3 };
        string[] names = { "Sony", "John" };

        PrintArray(numbers); // Automatically knows T is 'int'
        PrintArray(names);   // Automatically knows T is 'string'

        Console.WriteLine("\n--- Generic Classes ---");
        // We create a Box that holds an integer
        Box<int> intBox = new Box<int>(100);
        Console.WriteLine($"Integer Box: {intBox.Content}");

        // We create a Box that holds a string
        Box<string> stringBox = new Box<string>("Hello Generics!");
        Console.WriteLine($"String Box: {stringBox.Content}");
    }
}
