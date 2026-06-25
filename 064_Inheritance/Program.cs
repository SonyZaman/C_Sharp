// 064. Inheritance (The 'base' keyword)
/*
    Inheritance allows us to define a class that takes all the functionality from a parent class 
    and allows us to add more. It promotes code reusability.
    - Base Class (Parent)
    - Derived Class (Child)
*/
using System;

// Base Class (Parent)
public class Animal
{
    public string Name;

    public void Eat()
    {
        Console.WriteLine($"{Name} is eating.");
    }
}

// Derived Class (Child) inherits from Animal using the colon ':'
public class Dog : Animal
{
    public string Breed;

    // The Dog class can have its own specific methods
    public void Bark()
    {
        Console.WriteLine($"{Name} is barking! Woof woof!");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // We create an instance of the Derived class
        Dog myDog = new Dog();
        
        // It inherits properties and methods from the Parent class!
        myDog.Name = "Buddy"; 
        myDog.Breed = "Golden Retriever";

        Console.WriteLine($"My dog's name is {myDog.Name} and he is a {myDog.Breed}.");
        
        // Inherited method
        myDog.Eat();
        
        // Derived class's own method
        myDog.Bark();
    }
}
