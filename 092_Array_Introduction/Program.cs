// 092. Array Introduction
/*
    An array stores a fixed-size sequential collection of elements of the SAME type.
    Instead of declaring individual variables like number1, number2, number3, 
    you declare one array variable like 'numbers'.
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        // 1. Declaration and Initialization (Fixed Size)
        int[] numbers = new int[3]; // An array that can hold exactly 3 integers
        
        // 2. Assigning values via Index (Arrays are ZERO-indexed!)
        numbers[0] = 10;
        numbers[1] = 20;
        numbers[2] = 30;
        
        Console.WriteLine($"First element: {numbers[0]}");
        Console.WriteLine($"Second element: {numbers[1]}");
        Console.WriteLine($"Third element: {numbers[2]}");

        // 3. Declaration and Assignment on a single line!
        string[] names = { "Sony", "Maysha", "Raima" };
        
        Console.WriteLine($"\nName at index 1 is: {names[1]}");
    }
}
