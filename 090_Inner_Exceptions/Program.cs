// 090. Inner Exceptions
/*
    Sometimes you catch a technical error (like a database or network failure) 
    and you want to throw a new, more user-friendly exception.
    
    To ensure you don't lose the original technical context for debugging, 
    you pass the original exception as the 'InnerException' of the new exception.
*/
using System;

class Test
{
    public static void ReadFromFile()
    {
        try
        {
            // Simulate trying to read a file that doesn't exist
            throw new System.IO.FileNotFoundException("The configuration file 'config.txt' could not be found.");
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // We catch the low-level IO error, but we want to throw a higher-level 
            // "Application Exception" that makes more sense to the user.
            // We pass 'ex' as the second argument, which sets it as the InnerException!
            throw new ApplicationException("The application failed to start because a required configuration file is missing.", ex);
        }
    }

    public static void Main(string[] args)
    {
        try
        {
            ReadFromFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine("--- Outer (User-Friendly) Exception ---");
            Console.WriteLine(ex.Message);
            
            // Check if there is an InnerException attached
            if (ex.InnerException != null)
            {
                Console.WriteLine("\n--- Inner (Technical) Exception ---");
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
