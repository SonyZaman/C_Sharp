// 070. Interfaces
/*
    An interface is a completely "abstract class" that can only contain abstract methods and properties.
    By default, members of an interface are abstract and public.
    
    Why use Interfaces?
    C# does not support "multiple inheritance" (a class can only inherit from ONE base class).
    However, a class can implement MULTIPLE interfaces!
*/
using System;

// It is convention to start Interface names with a capital 'I'
public interface IAnimal
{
    void AnimalSound(); // interface method (does not have a body)
    void Run();         // interface method (does not have a body)
}

// Another interface
public interface IPet
{
    void BeFriendly();
}

// A class can implement multiple interfaces separated by commas
public class Pig : IAnimal, IPet
{
    public void AnimalSound()
    {
        // The body of AnimalSound() is provided here
        Console.WriteLine("The pig says: wee wee");
    }

    public void Run()
    {
        // The body of Run() is provided here
        Console.WriteLine("The pig runs fast.");
    }

    public void BeFriendly()
    {
        // The body of BeFriendly() is provided here
        Console.WriteLine("The pig wags its little tail.");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Pig myPig = new Pig();  // Create a Pig object
        myPig.AnimalSound();
        myPig.Run();
        myPig.BeFriendly();
    }
}
