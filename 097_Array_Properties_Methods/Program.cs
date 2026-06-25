// 097. Array Properties & Methods (including LINQ!)
/*
    Arrays come packed with extremely useful built-in methods.
    To use methods like Min(), Max(), Sum(), and Average(), you MUST include 'using System.Linq;'
*/
using System;
using System.Linq; // CRITICAL for advanced array math!

class Test
{
    public static void Main(string[] args)
    {
        int[] numbers = { 45, 12, 89, 5, 23, 77 };

        Console.WriteLine("--- Basic Array Methods ---");
        Console.WriteLine($"Length (Total items): {numbers.Length}");
        
        // Find the index of a specific item
        int index = Array.IndexOf(numbers, 89);
        Console.WriteLine($"The number 89 is at index: {index}");

        // Check if an item exists
        bool exists = Array.Exists(numbers, element => element == 5);
        Console.WriteLine($"Does the number 5 exist? {exists}");

        Console.WriteLine("\n--- LINQ Methods (Math) ---");
        Console.WriteLine($"Minimum Value: {numbers.Min()}");
        Console.WriteLine($"Maximum Value: {numbers.Max()}");
        Console.WriteLine($"Sum of all values: {numbers.Sum()}");
        Console.WriteLine($"Average value: {numbers.Average()}");

        Console.WriteLine("\n--- Sorting and Reversing ---");
        // Sort the array (Ascending order)
        Array.Sort(numbers);
        Console.WriteLine("Sorted: " + string.Join(", ", numbers));

        // Reverse the array (Descending order if called after Sort)
        Array.Reverse(numbers);
        Console.WriteLine("Reversed: " + string.Join(", ", numbers));

        Console.WriteLine("\n--- Clearing an Array ---");
        // Array.Clear(array, startIndex, lengthToClear)
        Array.Clear(numbers, 0, numbers.Length); 
        Console.WriteLine($"First element after clear: {numbers[0]}"); // Outputs 0
    }
}
