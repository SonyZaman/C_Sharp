
//sum and average of three numbers
class Test
{ 
    public static void Main(string[] args)
    {

        int number1, number2, number3, sum;
        double average;

        Console.Write("number1 = ");
        number1=Convert.ToInt32(Console.ReadLine());


        Console.Write("number2 = ");
        number2=Convert.ToInt32(Console.ReadLine());

        Console.Write("number3 = ");
        number3=Convert.ToInt32(Console.ReadLine());

        sum=number1+number2+number3;

        average=(double)sum/3;

        Console.WriteLine($"Sum = {sum}");
        Console.WriteLine($"Average ={average.ToString("F2")}");

    }
}