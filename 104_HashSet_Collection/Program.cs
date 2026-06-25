// 104. The HashSet<T> Collection
/*
    A HashSet is a highly optimized collection that ONLY stores unique elements.
    If you try to add a duplicate value, it will simply ignore it without crashing!
    It is much faster than a List for searching via .Contains().
*/
using System;
using System.Collections.Generic;

class Test
{
    public static void Main(string[] args)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();

        Console.WriteLine("--- Adding Items ---");
        // .Add() returns 'true' if the item was added, and 'false' if it was a duplicate!
        bool added1 = uniqueNumbers.Add(10);
        bool added2 = uniqueNumbers.Add(20);
        bool added3 = uniqueNumbers.Add(10); // Trying to add 10 again!

        Console.WriteLine($"Added 10? {added1}");
        Console.WriteLine($"Added 20? {added2}");
        Console.WriteLine($"Added 10 again? {added3}"); // Will be False!

        Console.WriteLine("\n--- HashSet Contents ---");
        foreach (int num in uniqueNumbers)
        {
            Console.WriteLine(num); // Only prints 10 and 20!
        }

        Console.WriteLine("\n--- Lightning Fast Searching ---");
        if (uniqueNumbers.Contains(20))
        {
            Console.WriteLine("20 is in the set!");
        }
    }
}
