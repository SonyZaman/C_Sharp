// 068. Method Hiding (The 'new' keyword)
/*
    Method Hiding is different from Overriding. 
    If a child class has a method with the exact same name as a parent class method, 
    but the parent method was NOT marked 'virtual', the child can "hide" the parent method 
    using the 'new' keyword.
*/
using System;

public class Parent
{
    public void DisplayMessage()
    {
        Console.WriteLine("Message from the PARENT class.");
    }
}

public class Child : Parent
{
    // 'new' explicitly tells the compiler: "Yes, I know I am hiding the parent's method, this is intentional."
    public new void DisplayMessage()
    {
        Console.WriteLine("Message from the CHILD class.");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Child myChild = new Child();
        myChild.DisplayMessage(); // Calls the Child's hidden method

        // IMPORTANT DIFFERENCE FROM OVERRIDING:
        // If we store the child in a Parent variable, it calls the PARENT'S method, not the child's!
        Parent hiddenChild = new Child();
        hiddenChild.DisplayMessage(); // Calls Parent! (If this was Overridden, it would have called Child)
    }
}
