// 067. Method Overriding (Run-Time Polymorphism - 'virtual' & 'override')
/*
    Method Overriding occurs when a Derived (child) class provides its own specific 
    implementation for a method that is already defined in its Base (parent) class.
    
    - 'virtual': Used in the parent class to allow overriding.
    - 'override': Used in the child class to actually override it.
*/
using System;

public class Animal
{
    // The 'virtual' keyword says: "Children are allowed to change how this works."
    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a generic sound.");
    }
}

public class Cat : Animal
{
    // The 'override' keyword says: "I am changing the parent's method to do this instead."
    public override void MakeSound()
    {
        Console.WriteLine("The cat says: Meow!");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("The dog says: Woof!");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Animal myAnimal = new Animal();
        Animal myCat = new Cat(); // Notice we can store a Cat in an Animal variable!
        Animal myDog = new Dog();

        // At runtime, C# knows the EXACT type of object and calls the correct overridden method
        myAnimal.MakeSound();
        myCat.MakeSound();
        myDog.MakeSound();
    }
}
