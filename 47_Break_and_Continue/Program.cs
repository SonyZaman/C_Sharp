

class Test
{
    public static void Main(string[] args)
    {  
        for(int i=1; i<=100; i++)
        {

            if (i == 50)
            {
                break;
            }

            if(i % 2 == 0 || i % 3 == 0)
            {
                continue;
            }
            
            Console.WriteLine(i);
        }
     }

}