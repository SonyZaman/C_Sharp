// 71. Sealed Classes and Methods
/*
    The 'sealed' keyword stops other classes from inheriting from a class, 
    or stops a derived class from further overriding a method.
    
    Use it when you want to lock down a class and ensure its behavior cannot be modified by inheritance.
*/
using System;

// A sealed class CANNOT be inherited
public sealed class SecuritySystem
{
    public void DisplayStatus()
    {
        Console.WriteLine("Security System is Active. (Cannot be modified)");
    }
}

/* 
// UNCOMMENTING THIS WILL CAUSE AN ERROR:
public class AdvancedSecurity : SecuritySystem 
{
    // Cannot inherit from sealed class 'SecuritySystem'
}
*/

class Test
{
    public static void Main(string[] args)
    {
        SecuritySystem sec = new SecuritySystem();
        sec.DisplayStatus();
        
        Console.WriteLine("The 'SecuritySystem' class is sealed, meaning no one can inherit from it to alter its core behavior!");
    }
}
