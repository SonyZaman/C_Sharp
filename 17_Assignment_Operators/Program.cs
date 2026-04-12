
//assignment operators


class Test
{
    
    public static void Main()
    {
        int number=20;
        double div=44;
        
        Console.WriteLine($"{number}");

        number+=5; //number=number+5
        Console.WriteLine($"{number}");

        number-=3; //number=number-3
        Console.WriteLine($"{number}");

        number*=2; //number=number*2
        Console.WriteLine($"{number}");

        div/=5; //number=number/5
        Console.WriteLine($"{div:F2}");
        Console.WriteLine($"{div.ToString("F2")}");


    }
}