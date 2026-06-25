// 107. Advanced Enums (Bitwise Flags & Parsing)
/*
    The [Flags] attribute allows an enum variable to hold MULTIPLE values at the same time using Bitwise operators!
    We can also Parse strings directly into Enums.
*/
using System;

// 1. Bitwise Flags Enum
// To use [Flags], the underlying values MUST be powers of 2 (1, 2, 4, 8, 16...)
[Flags]
public enum FilePermissions
{
    None = 0,
    Read = 1,       // 0001
    Write = 2,      // 0010
    Execute = 4,    // 0100
    All = Read | Write | Execute // 0111
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- [Flags] Bitwise Enums ---");
        
        // We use the Bitwise OR (|) to combine permissions!
        FilePermissions myPermissions = FilePermissions.Read | FilePermissions.Write;
        
        Console.WriteLine($"My Permissions: {myPermissions}"); // Outputs: Read, Write

        // We use the .HasFlag() method to check for a specific permission
        bool canExecute = myPermissions.HasFlag(FilePermissions.Execute);
        bool canRead = myPermissions.HasFlag(FilePermissions.Read);
        
        Console.WriteLine($"Can I execute? {canExecute}"); // False
        Console.WriteLine($"Can I read? {canRead}");       // True

        Console.WriteLine("\n--- Parsing Strings to Enums ---");
        string userInput = "Execute";

        // Converts the string "Execute" into the actual FilePermissions.Execute enum!
        // We use 'true' to ignore case (e.g. "execute" would also work)
        if (Enum.TryParse(userInput, true, out FilePermissions parsedPermission))
        {
            Console.WriteLine($"Successfully parsed string into Enum: {parsedPermission}");
        }
        else
        {
            Console.WriteLine("Failed to parse.");
        }
    }
}
