


class Test
{
    
    public static void Main(string[] args)
    {
        double fahrenheit, celcius;
        Console.Write("fahrenheit = ");

        fahrenheit=Convert.ToDouble(Console.ReadLine());

        celcius=(double)(fahrenheit-32)/1.8;
       // Console.WriteLine($"Celcius={celcius.ToString("F2")}");
       Console.WriteLine($"Celcius= {celcius:F2} degrees");



    }
}