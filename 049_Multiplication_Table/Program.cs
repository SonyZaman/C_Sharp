class Test
{
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter start number:");
        int startNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter end number:");
        int endNumber = Convert.ToInt32(Console.ReadLine());    

        for(int j=startNumber;j<=endNumber;j++)
        {
           for(int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{j} x {i} = {j * i}");
        }
        Console.WriteLine("--------------------------");
        }

        

    }
}