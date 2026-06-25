// 138. Memory Management (IDisposable and 'using' blocks)
/*
    When you open a File Stream or a Database Connection, it asks the Operating System for memory.
    If you forget to close it, that memory is locked forever (Memory Leak).
    
    The 'IDisposable' interface and 'using' statement guarantee that memory is 
    destroyed the exact second you are done with it.
*/
using System;
using System.IO;

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- The 'using' Statement ---");

        // The 'using' keyword creates a safe boundary. 
        // When the code exits these curly braces { }, it AUTOMATICALLY calls .Dispose() 
        // on the StreamWriter to clean up the memory and close the file.
        // It does this EVEN IF the application crashes with an exception!

        using (StreamWriter writer = new StreamWriter("safe_log.txt"))
        {
            writer.WriteLine("This file is open and taking up memory.");
            Console.WriteLine("Writing to file stream...");
            
            // Imagine an Exception happens right here!
            // Without 'using', the file would remain locked open forever!
        } // <--- The second it hits this brace, memory is instantly freed.
        
        Console.WriteLine("File stream was safely closed and memory was wiped!");

        
        Console.WriteLine("\n--- Modern Syntax (C# 8+) ---");
        // In modern C#, you don't even need the curly braces! 
        // You just put 'using' before the variable. 
        // It automatically destroys the memory when the method finishes running.
        
        using StreamReader reader = new StreamReader("safe_log.txt");
        string content = reader.ReadToEnd();
        Console.WriteLine("Read content safely: " + content);

        // When Main() ends in a few milliseconds, 'reader' will be automatically destroyed!
    }
}
