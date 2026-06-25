// 074. Calling Parent Constructors (The 'base' keyword)
/*
    When a Child class inherits from a Parent class, it automatically calls the Parent's default constructor.
    But what if the Parent's constructor requires arguments?
    We must use the 'base(...)' keyword to pass those arguments UP to the parent!
*/
using System;

public class Animal
{
    public string Name;

    // Parent Constructor requires an argument!
    public Animal(string name)
    {
        Name = name;
        Console.WriteLine($"Animal constructor called. Name set to: {Name}");
    }
}

public class Dog : Animal
{
    public string Breed;

    // The Child constructor MUST pass a name up to the Parent using ': base(...)'
    public Dog(string name, string breed) : base(name)
    {
        Breed = breed;
        Console.WriteLine($"Dog constructor called. Breed set to: {Breed}");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // When we create a Dog, it first calls the Animal constructor, then the Dog constructor!
        Dog myDog = new Dog("Buddy", "Golden Retriever");
        
        Console.WriteLine($"\nMy dog's name is {myDog.Name} and he is a {myDog.Breed}.");
    }
}
