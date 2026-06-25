// 122. LINQ: Safely Finding Items (.FirstOrDefault)
/*
    When searching for a specific item, .First() will CRASH if nothing is found.
    Always use .FirstOrDefault()! It returns 'null' (or the default value) 
    instead of crashing if the item doesn't exist.
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    public static void Main(string[] args)
    {
        List<string> colors = new List<string> { "Red", "Blue", "Green" };

        Console.WriteLine("--- Using .First() ---");
        string firstBlue = colors.First(c => c == "Blue");
        Console.WriteLine($"Found: {firstBlue}");

        // WARNING: The following line would crash the program with an Exception!
        // string firstYellow = colors.First(c => c == "Yellow");

        Console.WriteLine("\n--- Using .FirstOrDefault() [SAFE] ---");
        // Instead of crashing, this gracefully returns null
        string safeYellow = colors.FirstOrDefault(c => c == "Yellow");

        if (safeYellow == null)
        {
            Console.WriteLine("Yellow was not found, but we didn't crash!");
        }

        Console.WriteLine("\n--- SingleOrDefault ---");
        // SingleOrDefault: Ensures there is EXACTLY ONE match. 
        // Returns null if 0 matches. Crashes if there is MORE than 1 match!
        string singleRed = colors.SingleOrDefault(c => c == "Red");
        Console.WriteLine($"Single match: {singleRed}");
    }
}
