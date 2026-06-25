// 130. Null Operators (?. and ?? and ??=)
/*
    NullReferenceExceptions crash applications more than anything else.
    Modern C# provides beautiful operators to handle nulls safely without writing 'if (x != null)'.
*/
using System;

public class User
{
    public string Name { get; set; }
    // A User MIGHT have a Profile, or it might be null!
    public Profile ProfileData { get; set; } 
}

public class Profile
{
    public string Bio { get; set; }
}

class Test
{
    public static void Main(string[] args)
    {
        User activeUser = new User { Name = "Sony" }; // Note: ProfileData is NULL!

        Console.WriteLine("--- 1. The Null-Conditional Operator (?.) ---");
        // Old Way: if (activeUser != null && activeUser.ProfileData != null) { ... }
        
        // Modern Way: Add a '?' before the dot. 
        // If anything in the chain is null, it immediately stops and returns null instead of crashing!
        string userBio = activeUser?.ProfileData?.Bio;
        
        Console.WriteLine($"Bio is null? {userBio == null}"); // True (It didn't crash!)


        Console.WriteLine("\n--- 2. The Null-Coalescing Operator (??) ---");
        // What if we want to provide a DEFAULT value if something is null?
        // Old Way: string bio = (userBio != null) ? userBio : "No Bio Available";

        // Modern Way: Use '??'. It means "Use the left side, UNLESS it's null, then use the right side".
        string safeBio = activeUser?.ProfileData?.Bio ?? "No Bio Available";
        Console.WriteLine($"Bio: {safeBio}");


        Console.WriteLine("\n--- 3. The Null-Coalescing Assignment Operator (??=) ---");
        // If the variable is null, assign it a value! If it already has a value, do nothing.
        
        string username = null;
        
        username ??= "Guest_12345"; // username is null, so it gets assigned!
        Console.WriteLine($"Username after first check: {username}");

        username ??= "SuperAdmin"; // username is NOT null anymore, so it ignores this line!
        Console.WriteLine($"Username after second check: {username}");
    }
}
