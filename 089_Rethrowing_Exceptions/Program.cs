// 089. Rethrowing Exceptions (throw; vs throw ex;)
/*
    Rethrowing an exception is when you catch an error, do something (like logging it), 
    and then throw it again so a higher-level method can handle it.
    
    CRITICAL INTERVIEW TOPIC:
    - 'throw;' -> Preserves the original Stack Trace (shows exactly which line originally caused the error).
    - 'throw ex;' -> Resets the Stack Trace to the current line (makes debugging much harder because you lose the origin).
    
    Always use 'throw;' when rethrowing!
*/
using System;

class Test
{
    public static void MethodThatFails()
    {
        // Pretend an error happens deep inside this method
        int result = 10 / 0; // This will throw a DivideByZeroException
    }

    public static void BadRethrow()
    {
        try
        {
            MethodThatFails();
        }
        catch (Exception ex)
        {
            Console.WriteLine("BadRethrow: Caught the error, now throwing it poorly...");
            throw ex; // BAD PRACTICE: This resets the stack trace to this line!
        }
    }

    public static void GoodRethrow()
    {
        try
        {
            MethodThatFails();
        }
        catch (Exception ex)
        {
            Console.WriteLine("GoodRethrow: Caught the error, now throwing it correctly...");
            throw; // GOOD PRACTICE: This preserves the original stack trace!
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Testing BAD Rethrow (throw ex;) ---");
        try
        {
            BadRethrow();
        }
        catch (Exception ex)
        {
            // Notice how the Stack Trace says the error happened inside 'BadRethrow' instead of 'MethodThatFails'
            Console.WriteLine($"Stack Trace:\n{ex.StackTrace}\n");
        }

        Console.WriteLine("--- Testing GOOD Rethrow (throw;) ---");
        try
        {
            GoodRethrow();
        }
        catch (Exception ex)
        {
            // Notice how the Stack Trace correctly points to 'MethodThatFails' as the origin
            Console.WriteLine($"Stack Trace:\n{ex.StackTrace}\n");
        }
    }
}
