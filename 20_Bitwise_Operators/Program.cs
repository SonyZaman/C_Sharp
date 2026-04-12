//bitwise operators

class Test
{
    public static void Main(string[] args)
    {
        
        int num1=15;
        int num2=12;
        int result;

        result=num1 & num2; //AND
        Console.WriteLine($"Bitwise AND: {num1} & {num2} = {result}"); //12

        result = num1 | num2;//OR
        Console.WriteLine($"Bitwise OR: {num1} | {num2}= {result}"); //15

        result=num1^num2;//X-OR
        Console.WriteLine($"Bitwise XOR: {num1}^{num2}={result}");

        result=num1>>2;//Right Shift
        Console.WriteLine($"Bitwise Right Shift: {num1}>>2={result}");

        result=num1<<2; //left shift
        Console.WriteLine($"Bitwise Left Shift: {num1}<<2={result}");
        



    }
}