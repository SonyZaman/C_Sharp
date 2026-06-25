
//method in class

class Person
{
    public string name;
    public int age;

    public void displayInfo()
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }

}

class Test
{
    public static void Main(string[] args)
    {
        Person p1= new Person();
        p1.name="Kamruzzaman Sony";
        p1.age=22;
        p1.displayInfo();

        Person p2=new Person();
        p2.name="Maysha";
        p2.age=20;
        p2.displayInfo();


    }
}