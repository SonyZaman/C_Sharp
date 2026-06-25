
//class example with multiple objects

class Person
{
    public string name;
    public int age;


}

class Test
{
    public static void Main(string[] args)
    {
        Person p1= new Person();
        p1.name="Kamruzzaman Sony";
        p1.age=22;

        Person p2=new Person();
        p2.name="Maysha";
        p2.age=20;

        Console.WriteLine("Person 1");
        Console.WriteLine($"Name: {p1.name}, Age: {p1.age}");

        Console.WriteLine("Person 2");
        Console.WriteLine($"Name: {p2.name}, Age: {p2.age}");

    }
}