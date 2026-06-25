// 096. Array User Input
/*
    How to let the user dynamically fill an array with data from the console!
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        Console.Write("How many numbers do you want to store? ");
        int size = int.Parse(Console.ReadLine()!);

        // Create an array of the exact size the user requested
        int[] numbers = new int[size];

        // Loop to gather input
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter number for index {i}: ");
            numbers[i] = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine("\n--- You entered the following numbers ---");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
