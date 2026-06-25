// 102. The List<T> Collection
/*
    List<T> is the most popular collection in C#.
    Unlike arrays, Lists can grow and shrink dynamically!
    You must include 'using System.Collections.Generic;' to use it.
*/
using System;
using System.Collections.Generic;

class Test
{
    public static void Main(string[] args)
    {
        // Create a dynamically resizing List of strings
        List<string> shoppingList = new List<string>();

        Console.WriteLine("--- Adding Items ---");
        shoppingList.Add("Milk");
        shoppingList.Add("Eggs");
        shoppingList.Add("Bread");
        
        // Insert at a specific index
        shoppingList.Insert(1, "Butter"); 

        foreach (string item in shoppingList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"\nTotal items: {shoppingList.Count}"); // Lists use .Count instead of .Length

        Console.WriteLine("\n--- Removing Items ---");
        shoppingList.Remove("Eggs"); // Removes the specific item
        shoppingList.RemoveAt(0);    // Removes the item at index 0 (Milk)

        foreach (string item in shoppingList)
        {
            Console.WriteLine(item);
        }
        
        Console.WriteLine("\n--- Searching a List ---");
        bool hasBread = shoppingList.Contains("Bread");
        Console.WriteLine($"Does it contain Bread? {hasBread}");
    }
}
