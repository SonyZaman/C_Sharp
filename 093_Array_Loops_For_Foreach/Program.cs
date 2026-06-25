// 093. Iterating Arrays using 'for' and 'foreach' Loops
using System;

class Test
{
    public static void Main(string[] args)
    {
        string[] fruits = { "Apple", "Banana", "Orange", "Mango" };

        Console.WriteLine("--- Using a standard FOR loop ---");
        // We use the '.Length' property to find out how many elements are in the array
        for (int i = 0; i < fruits.Length; i++)
        {
            Console.WriteLine($"Fruit at index {i}: {fruits[i]}");
        }

        Console.WriteLine("\n--- Using a FOREACH loop ---");
        // 'foreach' is much cleaner when you don't need the index number!
        foreach (string fruit in fruits)
        {
            Console.WriteLine($"Fruit: {fruit}");
        }
    }
}
