// 059. Constructor Value Setting
class Person
{
    public string name;
    public int age;

    public Person()
    {
        name="test";
        age=2;
        
    }

    public Person(string n,int a)
    {
        name=n;
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
        p1.DisplayInfo();

        Person p2=new Person("Sony",22);
        p2.DisplayInfo();


    }
}