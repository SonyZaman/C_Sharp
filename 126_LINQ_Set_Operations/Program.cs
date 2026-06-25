// 126. LINQ: Set Operations (.Distinct, .Union, .Intersect, .Except)
/*
    Set Operations are used to compare collections and remove duplicates.
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. Distinct (Remove Duplicates) ---");
        List<int> messyNumbers = new List<int> { 1, 1, 2, 2, 3, 3, 4 };
        var cleanNumbers = messyNumbers.Distinct(); // Removes all duplicates
        foreach (int n in cleanNumbers) Console.Write($"{n} ");
        Console.WriteLine("\n");


        List<int> listA = new List<int> { 1, 2, 3, 4, 5 };
        List<int> listB = new List<int> { 4, 5, 6, 7, 8 };


        Console.WriteLine("--- 2. Union (Combine & Remove Duplicates) ---");
        // Combines listA and listB into one list, but removes the overlapping 4 and 5.
        var unionList = listA.Union(listB);
        foreach (int n in unionList) Console.Write($"{n} "); // 1 2 3 4 5 6 7 8
        Console.WriteLine("\n");


        Console.WriteLine("--- 3. Intersect (Find Common Elements) ---");
        // Only returns items that exist in BOTH lists.
        var intersectList = listA.Intersect(listB);
        foreach (int n in intersectList) Console.Write($"{n} "); // 4 5
        Console.WriteLine("\n");


        Console.WriteLine("--- 4. Except (Find Differences) ---");
        // Returns items from listA that DO NOT exist in listB.
        var exceptList = listA.Except(listB);
        foreach (int n in exceptList) Console.Write($"{n} "); // 1 2 3
        Console.WriteLine("\n");
    }
}
