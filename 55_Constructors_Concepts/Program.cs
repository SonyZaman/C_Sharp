
//constructor--automatic call while creating object


class Person
{
    public string name;
    public int age;

    public Person()
    {
        Console.WriteLine("I am default constructor");
        
    }

    public void SetValue(string n,int a)
    {
        name =n;
        age=a;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }

}

class Test
{
    public static void Main(string[] args)
    {
        Person p1= new Person();
        p1.SetValue("Kamruzzaman Sony", 22);
        p1.DisplayInfo();

        Person p2=new Person();
        p2.SetValue("Maysha", 20);
        p2.DisplayInfo();


    }
}