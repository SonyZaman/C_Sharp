// 136. File I/O (Input / Output)
/*
    Until now, everything we wrote was lost when the app closed.
    To save data permanently, we write it to the hard drive using the 'System.IO' namespace.
*/
using System;
using System.IO; // CRITICAL for reading and writing files!
using System.Collections.Generic;

class Test
{
    public static void Main(string[] args)
    {
        // Define where we want to save our file
        string filePath = "my_database.txt";

        Console.WriteLine("--- 1. Writing to a File ---");
        // This will create the file if it doesn't exist, and completely OVERWRITE it if it does!
        File.WriteAllText(filePath, "Hello! This is my first permanently saved file!\n");
        Console.WriteLine($"Successfully wrote to '{filePath}'.");


        Console.WriteLine("\n--- 2. Appending to a File ---");
        // If we want to ADD data without deleting the old data, we use Append.
        List<string> newLines = new List<string> 
        { 
            "Line 2: User logged in.", 
            "Line 3: User clicked a button." 
        };
        File.AppendAllLines(filePath, newLines);
        Console.WriteLine("Successfully appended 2 new lines.");


        Console.WriteLine("\n--- 3. Reading from a File ---");
        // Let's read all the text back into our application!
        if (File.Exists(filePath))
        {
            string fileData = File.ReadAllText(filePath);
            Console.WriteLine("Here is the data currently on the hard drive:");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(fileData);
            Console.WriteLine("-------------------------------------------");
        }
        else
        {
            Console.WriteLine("File not found!");
        }

        // Note: For massive files (like 5GB logs), you shouldn't use ReadAllText. 
        // You should use a StreamReader to read it one line at a time to save RAM.
    }
}
