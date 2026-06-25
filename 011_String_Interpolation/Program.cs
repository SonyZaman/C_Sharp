
//output formatting
//string interpolation

class Test
{

    public static void Main(string[] args)
    {
        
        int number1=10;
        int number2=3;
        int result;

        result=number1+number2;
        Console.WriteLine($"{number1}+{number2}={result}");
        Console.WriteLine("{0}+{1}={2}",number1,number2,result);
        Console.WriteLine();

        result=number1-number2;
        Console.WriteLine($"{number1}-{number2}={result}");
        Console.WriteLine("{0}-{1}={2}",number1,number2,result);
        Console.WriteLine();

        result=number1*number2;
        Console.WriteLine($"{number1}*{number2}={result}");
        Console.WriteLine("{0}*{1}={2}",number1,number2,result);
        Console.WriteLine();

        double div=(double)number1 /number2;
        Console.WriteLine($"{number1}/{number2}={div.ToString("F3")}");
        Console.WriteLine("{0}/{1}={2:F3}",number1,number2,div);
        Console.WriteLine();

        int rem=number1 % number2;
        Console.WriteLine($"{number1}%{number2}={rem}");
        Console.WriteLine("{0}%{1}={2}",number1,number2,rem);
        Console.WriteLine();

        
        
    }

}