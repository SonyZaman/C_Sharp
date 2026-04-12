//fahrenheit to celsius
//celsius to fahrenheit

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Temperature Converter Started");
        Console.WriteLine("Choose 1. Fahrenheit to Celsius");
        Console.WriteLine("Choose 2. Celsius to Fahrenheit");
        Console.Write("Enter your choice: ");

        int choice=Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.Write("Enter temperature in Fahrenheit: ");
                double fahrenheit = Convert.ToDouble(Console.ReadLine());
                double celsius = (fahrenheit - 32) / 1.8;
                Console.WriteLine($"Temperature in Celsius: {celsius:F2}");
                break;

            case 2:
                Console.Write("Enter temperature in Celsius: ");
                celsius = Convert.ToDouble(Console.ReadLine());
                fahrenheit = (celsius * 9 / 5) + 32;
                Console.WriteLine($"Temperature in Fahrenheit: {fahrenheit}");
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }

    }
}