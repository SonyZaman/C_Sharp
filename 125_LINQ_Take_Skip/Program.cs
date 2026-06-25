// 125. LINQ: Partitioning (.Take, .Skip)
/*
    Partitioning is how we handle PAGINATION (e.g. Page 1, Page 2 of a website).
    - .Take(n) grabs the first 'n' elements.
    - .Skip(n) ignores the first 'n' elements and grabs everything else.
    By chaining them together, we can create data pages!
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    public static void Main(string[] args)
    {
        // Imagine a database of 10 products
        List<string> database = new List<string> 
        { 
            "Item1", "Item2", "Item3", "Item4", "Item5", 
            "Item6", "Item7", "Item8", "Item9", "Item10" 
        };

        Console.WriteLine("--- 1. Take() ---");
        // Grab only the first 3 items
        var firstThree = database.Take(3);
        foreach (var item in firstThree) Console.WriteLine(item);

        Console.WriteLine("\n--- 2. Skip() ---");
        // Ignore the first 3 items, grab the rest
        var skipThree = database.Skip(3);
        foreach (var item in skipThree) Console.WriteLine(item);


        Console.WriteLine("\n--- 3. Pagination (Skip + Take) ---");
        int pageSize = 3;

        // Page 1 (Skip 0, Take 3)
        var page1 = database.Skip(0).Take(pageSize);
        Console.WriteLine("Page 1:");
        foreach (var item in page1) Console.WriteLine($" - {item}");

        // Page 2 (Skip 3, Take 3)
        var page2 = database.Skip(1 * pageSize).Take(pageSize);
        Console.WriteLine("\nPage 2:");
        foreach (var item in page2) Console.WriteLine($" - {item}");
        
        // Page 3 (Skip 6, Take 3)
        var page3 = database.Skip(2 * pageSize).Take(pageSize);
        Console.WriteLine("\nPage 3:");
        foreach (var item in page3) Console.WriteLine($" - {item}");
    }
}
