
//Celsius to Fahrenheit conversion
class Test
{
    
    public static void Main(string[] args)
    {
        
        double fahrenheit, celsius;
        Console.Write("celsius = ");

        celsius=Convert.ToDouble(Console.ReadLine());

        fahrenheit=(1.8 * celsius)+32;
        Console.Write($"fahrenheit = {fahrenheit:F2} degrees");


    }
}